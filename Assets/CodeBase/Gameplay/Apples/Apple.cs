using System;
using CodeBase.Gameplay.Characters;
using UnityEngine;

namespace CodeBase.Gameplay.Apples
{
    public class Apple : MonoBehaviour
    {
        public event Action<Apple> PickUpped;

        private async void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                await character.CharacterBody.AddBodyPiece();
                gameObject.SetActive(false);
                PickUpped?.Invoke(this);
            }
        }
    }
}