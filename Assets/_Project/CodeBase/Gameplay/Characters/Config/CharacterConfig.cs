using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.CodeBase.Gameplay.Characters.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [TitleGroup("CharacterSpeed")]
        public float Speed;
        [TitleGroup("CharacterSpeed")]
        public float RotatingSpeed;

        [TitleGroup("CharacterBody")]
        public float PartsSpeed;
        [TitleGroup("CharacterBody")]
        public float PartsRotationSpeed;

        [TitleGroup("Character Start Parameters")]
        public Vector3 StartPosition;
        [TitleGroup("Character Start Parameters")]
        public int StartNumberBodyParts;
    }
}