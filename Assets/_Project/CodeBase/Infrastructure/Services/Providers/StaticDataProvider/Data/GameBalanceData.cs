using _Project.CodeBase.Gameplay.CameraControl.Config;
using _Project.CodeBase.Gameplay.Characters.Config;
using _Project.CodeBase.Gameplay.Services.Gravity.Config;
using _Project.CodeBase.Gameplay.Services.Spawners.Apples.Config;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data
{
    [CreateAssetMenu(menuName = "StaticData/Balance/GameBalanceData", fileName = "GameBalanceData")]
    public class GameBalanceData : ScriptableObject
    {
        public GravityConfig GravityConfig;
        public CharacterConfig CharacterConfig;
        public CameraConfig CameraConfig;
        public AppleSpawnerConfig AppleSpawnerConfig;
    }
}