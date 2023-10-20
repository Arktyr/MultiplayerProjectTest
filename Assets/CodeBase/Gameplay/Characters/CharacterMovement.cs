using CodeBase.Gameplay.Input.Joysticks;
using UnityEngine;

namespace CodeBase.Gameplay.Characters
{
    public class CharacterMovement
    {
        private Joystick _joystick;
        private Movement _movement;
        private Rotate _rotate;

        private float _speed;
        private float _rotatingSpeed;
        
        public void Construct(Joystick joystick,
            Movement movement,
            Rotate rotate,
            float speed,
            float rotatingSpeed)
        {
            _joystick = joystick;
            _movement = movement;
            _rotate = rotate;
            _speed = speed;
            _rotatingSpeed = rotatingSpeed;
        }
        
        public void Move()
        {
            Vector3 inputDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
            
            if (inputDirection.magnitude > 0)
                _rotate.RotateForward(inputDirection, _rotatingSpeed);
            
            _movement.Move(_speed);
        }
    }
}