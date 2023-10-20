using CodeBase.Gameplay.Services.Gravity;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data
{
    [CreateAssetMenu(menuName = "StaticData/Balance/GameBalanceData", fileName = "GameBalanceData")]
    public class GameBalanceData : ScriptableObject
    {
        public GravityConfig GravityConfig;
    }
}