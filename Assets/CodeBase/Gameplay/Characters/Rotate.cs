using UnityEngine;

namespace CodeBase.Gameplay.Characters
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingPart;
        
        public void RotateForward(Vector3 inputDirection, float rotatingSpeed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            
            _rotatingPart.localRotation = Quaternion.Slerp(_rotatingPart.localRotation, targetRotation,
                rotatingSpeed * Time.deltaTime); 
        }
    }
}