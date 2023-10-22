using CodeBase.Gameplay.Characters;
using UnityEngine;

namespace CodeBase.Gameplay.Apples
{
    public class AppleAttractor : MonoBehaviour
    {
        [SerializeField] private BodyParts _headParts;
        
        private const float _attractiveStrength = 10;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Apple apple))
            {
                apple.transform.localPosition = Vector3.Slerp(apple.transform.localPosition,
                    _headParts.BodyAttractionPart.transform.localPosition, _attractiveStrength * Time.deltaTime);
            }
        }
    }
}