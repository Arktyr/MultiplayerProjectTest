using UnityEngine;

namespace _Project.CodeBase.Gameplay.Services.Spawners.Apples.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/AppleSpawner", fileName = "AppleSpawnerConfig")]
    public class AppleSpawnerConfig : ScriptableObject
    {
        public float DistanceFromMesh;
        public int MaximumApplesOnLevel;
    }
}