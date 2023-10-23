using _Project.CodeBase.Gameplay.Input.Joysticks;
using UnityEngine;

namespace _Project.CodeBase.Gameplay.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private BodyParts _headParts;

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
                Rotate(inputDirection);

            Rigidbody bodyAttractionPart = _headParts.BodyAttractionPart;
            
            _headParts.BodyAttractionPart.MovePosition(bodyAttractionPart.position +
                                                      _headParts.BodyInputRotatingPart.transform.forward *
                                                      _speed * Time.deltaTime);
        }

        private void Rotate(Vector3 inputDirection)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

            Transform bodyInputRotatingPart = _headParts.BodyInputRotatingPart;
            
            bodyInputRotatingPart.localRotation =
                Quaternion.Slerp(bodyInputRotatingPart.localRotation, targetRotation,
                    _rotatingSpeed * Time.deltaTime); 
        }
    }
}