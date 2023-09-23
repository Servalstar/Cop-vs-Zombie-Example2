using UnityEngine;

namespace Services.Input.Contracts
{
    public interface IInputService
    {
        Vector2 Direction { get; }
        void SetJoystick(Joystick joystick);
    }
}