using System.Collections.Generic;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using _Project.CodeBase.Infrastructure.Services.Tickable;
using UnityEngine;

namespace _Project.CodeBase.Gameplay.Services.Gravity
{
    public class GravityAttraction : IGravityAttraction
    {
        private ITickableService _tickableService;
        
        private readonly GameObject _attractive;
        private Vector3 _gravityDirection;

        private readonly float _gravityStrength;
        private readonly float _timeToRotate;
        
        public GravityAttraction(GameObject attractive,
            ITickableService tickableService,
            IStaticDataProvider staticDataProvider)
        {
            _attractive = attractive;
            _tickableService = tickableService;
            
            _gravityStrength = staticDataProvider.GameBalanceData.GravityConfig.GravityStrength;
            _timeToRotate = staticDataProvider.GameBalanceData.GravityConfig.TimeToRotate;
        }

        private readonly List<Rigidbody> _attractionObjects = new();

        public void Enable() => 
            _tickableService.FixedTicked += Attract;

        public void Disable() => 
            _tickableService.FixedTicked -= Attract;

        public void RemoveObjectFromAttraction(Rigidbody attraction) => 
            _attractionObjects.Remove(attraction);

        public void AddObjectToAttraction(Rigidbody attraction) => 
            _attractionObjects.Add(attraction);

        private void Attract()
        {
            foreach (var attraction in _attractionObjects)
            {
                _gravityDirection = (attraction.position - _attractive.transform.position).normalized;

                attraction.AddForce(_gravityDirection * _gravityStrength);
        
                Rotate(attraction);
            }
        }

        private void Rotate(Rigidbody attraction)
        {
            attraction.rotation = Quaternion.Slerp(attraction.rotation,
                Quaternion.FromToRotation(attraction.transform.up, _gravityDirection),
                _timeToRotate * Time.deltaTime) * attraction.rotation;
        }
    }
}