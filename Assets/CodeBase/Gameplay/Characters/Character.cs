using System;
using CodeBase.Infrastructure.Services.Tickable;
using UnityEngine;
using VContainer;

namespace CodeBase.Gameplay.Characters
{
    public class Character : MonoBehaviour
    {
        private ITickableService _tickableService;
        
        [Inject]
        public void Inject(ITickableService tickableService) => 
            _tickableService = tickableService;
        
        [field: SerializeField] public CharacterMovement CharacterMovement { get; private set; }
        [field: SerializeField] public CharacterBody CharacterBody { get; private set; }
        
        public void Initialize()
        {
            _tickableService.FixedTicked += CharacterMovement.Move;
            _tickableService.FixedTicked += CharacterBody.ShiftPieces;
        }

        private void OnDestroy()
        {
            _tickableService.FixedTicked -= CharacterMovement.Move;
            _tickableService.FixedTicked -= CharacterBody.ShiftPieces;
        }
    }
}