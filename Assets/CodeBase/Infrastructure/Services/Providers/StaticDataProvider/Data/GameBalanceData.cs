using CodeBase.Gameplay.Characters.Config;
using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Gameplay.Services.Gravity.Config;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data
{
    [CreateAssetMenu(menuName = "StaticData/Balance/GameBalanceData", fileName = "GameBalanceData")]
    public class GameBalanceData : ScriptableObject
    {
        public GravityConfig GravityConfig;
        public CharacterConfig CharacterConfig;
    }
}