using UnityEngine;

namespace _Project.CodeBase.Gameplay.CameraControl.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Configs/Camera", fileName = "CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        public bool IsLookedAtCharacter;
        public Vector3 Offset;
    }
}