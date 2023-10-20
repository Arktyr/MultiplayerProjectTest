using UnityEngine;

namespace CodeBase.Gameplay.Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingPart;
        private Rigidbody _character;

        private void Start() => 
            _character = GetComponent<Rigidbody>();

        public void Move(float speed) => 
            _character.MovePosition(_character.position + _rotatingPart.forward * speed * Time.deltaTime);
    }
}