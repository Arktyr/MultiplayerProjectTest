using UnityEngine;

namespace CodeBase.Gameplay.Services.Spawners.Apples
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/AppleSpawner", fileName = "AppleSpawnerConfig")]
    public class AppleSpawnerConfig : ScriptableObject
    {
        public float DistanceFromMesh;
        public int MaximumApplesOnLevel;
    }
}