using UnityEngine;

namespace Code.Services.InputService
{
    public class DesctopInputService : IInputService
    {
        private PlayerInputActions _playerInput;
        
        public DesctopInputService()
        {
            _playerInput = new PlayerInputActions();
        }
        
        public void Enable()
            => _playerInput.Enable();

        public void Disable()
            => _playerInput.Disable();

        public Vector2 ReadMovement()
            => _playerInput.Player.Move.ReadValue<Vector2>();

        public Vector2 ReadLook()
            => _playerInput.Player.Look.ReadValue<Vector2>();

        public bool ReadJump()
            => _playerInput.Player.Jump.IsPressed();
    }
}