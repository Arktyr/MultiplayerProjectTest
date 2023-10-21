using CodeBase.Infrastructure.Services.Tickable;
using UnityEngine;
using VContainer;

namespace CodeBase.Gameplay.CameraControl
{
    public class CameraMovement : MonoBehaviour
    {
        private ITickableService _tickableService;
        
        private Transform _character;
        private Vector3 _offset;

        private bool _isLookedAtCharacter;

        [Inject]
        public void Inject(ITickableService tickableService)
        {
            _tickableService = tickableService;
        }

        public void Construct(Transform character,
            Vector3 offset,
            bool isLookedAtCharacter)
        {
            _character = character;
            _offset = offset;
            
            _isLookedAtCharacter = isLookedAtCharacter;
        }

        public void Initialize()
        {
            _tickableService.LateTicked += MoveCamera;
        }

        private void MoveCamera()
        {
           transform.position = _character.position + (-_character.forward * _offset.z) + (_character.up * _offset.y);
            
            if (_isLookedAtCharacter)
                transform.LookAt(_character, _character.up);
        }

        private void OnDestroy()
        {
            _tickableService.LateTicked -= MoveCamera;
        }
    }
}
