using UnityEngine;

namespace CodeBase.Gameplay.CameraControl.Config
{
    [CreateAssetMenu(menuName = "StaticData/Balance/Config/Camera", fileName = "CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        public bool IsLookedAtCharacter;
        public Vector3 Offset;
    }
}