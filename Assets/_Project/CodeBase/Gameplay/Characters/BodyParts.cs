using UnityEngine;

namespace _Project.CodeBase.Gameplay.Characters
{
    public class BodyParts : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody BodyAttractionPart { get; private set; }
        [field: SerializeField] public Transform BodyInputRotatingPart { get; private set; }
    }
}