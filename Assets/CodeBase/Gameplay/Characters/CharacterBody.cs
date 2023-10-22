using System.Collections.Generic;
using CodeBase.Gameplay.Characters.Config;
using CodeBase.Infrastructure.Factories.Characters;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace CodeBase.Gameplay.Characters
{
    public class CharacterBody : MonoBehaviour
    {
        [SerializeField] private BodyParts _headParts;

        private ICharacterFactory _characterFactory;
        private CharacterConfig _characterConfig;
        
        [Inject]
        public void Inject(ICharacterFactory characterFactory,
            IStaticDataProvider staticDataProvider)
        {
            _characterFactory = characterFactory;

            _characterConfig = staticDataProvider.GameBalanceData.CharacterConfig;
        }

        private readonly List<BodyParts> _bodyPieces = new();

        public async UniTask AddBodyPiece()
        {
            BodyParts bodyParts = await _characterFactory.CreateBodyPart();
            _bodyPieces.Add(bodyParts);
        }
        
        public void ShiftPieces()
        {
            if (_bodyPieces.Count == 0)
                return;
            
            for (int i = 0; i < _bodyPieces.Count; i++)
            {
                if (i == 0)
                {
                    SlerpMove(_bodyPieces[i].BodyAttractionPart.transform,
                        _headParts.BodyAttractionPart.transform.position, _characterConfig.PartsSpeed);

                    Rotate(_bodyPieces[i].BodyAttractionPart.transform, _headParts.BodyAttractionPart.rotation,
                        _characterConfig.PartsRotating);
                  
                    LocalRotate(_bodyPieces[i].BodyInputRotatingPart, _headParts.BodyInputRotatingPart.localRotation,
                        _characterConfig.PartsRotating);

                    continue;
                }

                SlerpMove(_bodyPieces[i].BodyAttractionPart.transform,
                    _bodyPieces[i-1].BodyAttractionPart.position, _characterConfig.PartsSpeed);

                LocalRotate(_bodyPieces[i].BodyInputRotatingPart, _bodyPieces[i - 1].BodyInputRotatingPart.rotation,
                    _characterConfig.PartsRotating);
            }
        }

        private void SlerpMove(Transform movePart, Vector3 direction, float speed) => 
            movePart.position = Vector3.Slerp(movePart.position, direction, speed * Time.deltaTime);

        private void Rotate(Transform rotatePart, Quaternion rotateTarget, float rotatingSpeed) =>
            rotatePart.rotation = Quaternion.Slerp(rotatePart.rotation,
                rotateTarget, rotatingSpeed * Time.deltaTime);
        
        private void LocalRotate(Transform rotatePart, Quaternion rotateTarget, float rotatingSpeed) =>
            rotatePart.localRotation = Quaternion.Slerp(rotatePart.localRotation,
                rotateTarget, rotatingSpeed * Time.deltaTime);
    }
}