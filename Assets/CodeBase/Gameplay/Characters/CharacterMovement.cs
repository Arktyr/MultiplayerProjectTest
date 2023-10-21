using CodeBase.Gameplay.Input.Joysticks;
using UnityEngine;

namespace CodeBase.Gameplay.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private Rotate _rotate;
        
        private Joystick _joystick;

        private float _speed;
        private float _rotatingSpeed;
        
        public void Construct(Joystick joystick,
            float speed,
            float rotatingSpeed)
        {
            _joystick = joystick;
           
            _speed = speed;
            _rotatingSpeed = rotatingSpeed;
        }
        
        public void Move()
        {
            Vector3 inputDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
            
            if (inputDirection.magnitude > 0.1f)
                _rotate.RotateForward(inputDirection, _rotatingSpeed);
            
            _movement.Move(_speed);
        }
    }
}