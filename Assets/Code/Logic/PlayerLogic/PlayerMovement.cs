using Code.Services.InputService;
using UnityEngine;

namespace Code.Logic.PlayerLogic
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerJump))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private PlayerJump playerJump;

        private IInputService _input;
        private float _speed;
        private Vector3 _inputDirection;

        public void Init(IInputService input)
        {
            _input = input;
        }
        
        public void Move(float moveSpeed, float speedChangeRate)
        {
            _speed = CalculateMovementSpeed(moveSpeed, speedChangeRate);
            _inputDirection = CalculateInputDirection();

            controller.Move(_inputDirection.normalized 
                            * (_speed * Time.deltaTime)
                            + new Vector3(0.0f, playerJump.VerticalVelocity, 0.0f) 
                            * Time.deltaTime);
        }

        private float CalculateMovementSpeed(float moveSpeed, float speedChangeRate)
        {
            float speed;
            
            float targetSpeed = moveSpeed;

            if (_input.ReadMovement() == Vector2.zero) 
                targetSpeed = 0.0f;

            float currentHorizontalSpeed = new Vector3(controller.velocity.x, 0.0f, controller.velocity.z).magnitude;

            float speedOffset = 0.1f;
            float inputMagnitude = 1f;

            if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                speed = Mathf.Lerp(currentHorizontalSpeed, 
                    targetSpeed * inputMagnitude, 
                    Time.deltaTime * speedChangeRate);

                speed = Mathf.Round(speed * 1000f) / 1000f;
            }
            else
            {
                speed = targetSpeed;
            }

            return speed;
        }

        private Vector3 CalculateInputDirection()
        {
            Vector3 inputDirection = new Vector3(_input.ReadMovement().x, 0.0f, _input.ReadMovement().y).normalized;

            if (_input.ReadMovement() != Vector2.zero)
            {
                inputDirection = transform.right * _input.ReadMovement().x + transform.forward * _input.ReadMovement().y;
            }

            return inputDirection;
        }
    }
}