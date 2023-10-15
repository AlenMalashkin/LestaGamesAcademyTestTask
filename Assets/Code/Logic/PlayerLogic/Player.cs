using System;
using Code.Infrastructure.Update;
using Code.Services;
using Code.Services.InputService;
using Code.StaticData.PlayerStaticData;
using UnityEngine;

namespace Code.Logic.PlayerLogic
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCamera))]
    [RequireComponent(typeof(PlayerJump))]
    public class Player : MonoBehaviour, ITickable
    {
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private PlayerStaticData playerStaticData;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private PlayerJump playerJump;

        private IInputService _input;
        private IUpdater _updater;

        public Transform CameraRoot => cameraRoot;
        
        private void Awake()
        {
            _input = ServiceLocator.Container.Resolve<IInputService>();
            _updater = ServiceLocator.Container.Resolve<IUpdater>();

            playerMovement.Init(_input);
            playerCamera.Init(_input);
            playerJump.Init(_input);
        }

        private void OnEnable()
        {
            _updater.AddTickable(this);
        }

        private void OnDisable()
        {
            _updater.RemoveTickable(this);
        }

        public void Tick()
        {
            MovementLogic();
            JumpAndGravityLogic();
        }

        private void LateUpdate()
        {
            CameraLogic();
        }

        private void MovementLogic()
        {
            playerMovement.Move(playerStaticData.MoveSpeed, playerStaticData.SpeedChangeRate);
        }

        private void JumpAndGravityLogic()
        {
            playerJump.GroundedCheck(playerStaticData.GroundedOffset,
                playerStaticData.GroundedRadius,
                playerStaticData.GroundLayers);

            playerJump.JumpAndApplyGravity(playerStaticData.JumpHeight,
                playerStaticData.Gravity,
                playerStaticData.JumpTimeout);
        }

        private void CameraLogic()
        {
            playerCamera.CameraRotation(playerStaticData.RotationSpeed,
                playerStaticData.TopClamp,
                playerStaticData.BottomClamp);
        }
    }
}