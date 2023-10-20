using UnityEngine;

namespace CodeBase.Gameplay.Services.Gravity
{
    public interface IGravityAttraction
    {
        public void Enable();
        public void Disable();
        public void RemoveObjectFromAttraction(Rigidbody attraction);
        public void AddObjectToAttraction(Rigidbody attraction);
    }
}