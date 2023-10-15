using Code.Services.InputService;
using UnityEngine;

namespace Code.Logic.PlayerLogic
{
    public class PlayerCamera : MonoBehaviour
    {
        private const float Threshold = 0.01f;

        [SerializeField] private GameObject cinemachineCameraRoot;

        private IInputService _input;
        private float _rotationVelocity;
        private float _cinemachineTargetPitch;

        public void Init(IInputService input)
        {
            _input = input;
        }
        
        public void CameraRotation(float rotationSpeed, float topClamp, float bottomClamp)
        {
            if (_input.ReadLook().sqrMagnitude >= Threshold)
            {
                float deltaTimeMultiplier = Time.deltaTime;
				
                _cinemachineTargetPitch += _input.ReadLook().y * rotationSpeed * deltaTimeMultiplier;
                _rotationVelocity = _input.ReadLook().x * rotationSpeed * deltaTimeMultiplier;

                _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, bottomClamp, topClamp);

                cinemachineCameraRoot.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

                transform.Rotate(Vector3.up * _rotationVelocity);
            }
        }
        
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}