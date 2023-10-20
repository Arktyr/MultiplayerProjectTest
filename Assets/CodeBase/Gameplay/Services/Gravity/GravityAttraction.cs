using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Services.Gravity
{
    public class GravityAttraction : IGravityAttraction
    {
        private readonly GameObject _attractive;
        private Vector3 _gravityDirection;

        private float _gravityStrength;
        private float _timeToRotate;
        
        public GravityAttraction(GameObject attractive)
        {
            _attractive = attractive;
        }

        private readonly List<Rigidbody> _attractionObjects = new();

        public void Enable()
        {
            
        }

        public void Disable()
        {
            
        }

        public void RemoveObjectFromAttraction(Rigidbody attraction) => 
            _attractionObjects.Remove(attraction);

        public void AddObjectToAttraction(Rigidbody attraction) => 
            _attractionObjects.Add(attraction);

        private void Attract()
        {
            foreach (var attraction in _attractionObjects)
            {
                if (attraction == null)
                    RemoveObjectFromAttraction(attraction);
                
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