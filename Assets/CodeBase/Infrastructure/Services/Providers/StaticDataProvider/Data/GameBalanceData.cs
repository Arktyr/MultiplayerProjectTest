﻿using CodeBase.Gameplay.Apples.Config;
using CodeBase.Gameplay.CameraControl;
using CodeBase.Gameplay.CameraControl.Config;
using CodeBase.Gameplay.Characters.Config;
using CodeBase.Gameplay.Services.Gravity;
using CodeBase.Gameplay.Services.Gravity.Config;
using CodeBase.Gameplay.Services.Spawners.Apples;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Providers.StaticDataProvider.Data
{
    [CreateAssetMenu(menuName = "StaticData/Balance/GameBalanceData", fileName = "GameBalanceData")]
    public class GameBalanceData : ScriptableObject
    {
        public GravityConfig GravityConfig;
        public AppleAttractionConfig AppleAttractionConfig;
        public CharacterConfig CharacterConfig;
        public CameraConfig CameraConfig;
        public AppleSpawnerConfig AppleSpawnerConfig;
    }
}