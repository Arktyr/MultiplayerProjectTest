using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Apple : MonoBehaviour
    {
        public event Action<Apple> PickUpped;

        private void OnTriggerEnter(Collider other) => 
            PickUpped?.Invoke(this);
    }
}