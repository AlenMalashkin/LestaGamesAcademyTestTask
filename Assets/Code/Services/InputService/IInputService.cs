using UnityEngine;

namespace Code.Services.InputService
{
    public interface IInputService : IService
    {
        void Enable();
        void Disable();
        Vector2 ReadMovement();
        Vector2 ReadLook();
        bool ReadJump();
    }
}