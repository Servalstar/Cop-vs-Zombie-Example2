using Services.Input.Contracts;
using UnityEngine;

namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 Direction { get; }

        private Joystick _joystick;

        public void SetJoystick(Joystick joystick)
        {
            _joystick = joystick;
        }

        protected Vector2 JoystickDirection()
        {
            return _joystick.Direction;
        }
    }
}