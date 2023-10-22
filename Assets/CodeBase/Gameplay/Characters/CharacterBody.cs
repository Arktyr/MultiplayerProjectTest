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

        private float _partsSpeed;
        private float _partsRotationSpeed;
        
        [Inject]
        public void Inject(ICharacterFactory characterFactory,
            IStaticDataProvider staticDataProvider)
        {
            _characterFactory = characterFactory;
            
           _partsSpeed = staticDataProvider.GameBalanceData.CharacterConfig.PartsSpeed;
           _partsRotationSpeed = staticDataProvider.GameBalanceData.CharacterConfig.PartsRotationSpeed;
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
                Rigidbody bodyAttractionPart = _bodyPieces[i].BodyAttractionPart;
                Transform bodyRotationPart = _bodyPieces[i].BodyInputRotatingPart;

                if (i == 0)
                {
                    Rigidbody headAttractionPart = _headParts.BodyAttractionPart;
                    Transform headRotationPart = _headParts.BodyInputRotatingPart;
                    
                    SlerpMove(bodyAttractionPart.transform, headAttractionPart.position);

                    Rotate(bodyAttractionPart.transform, headAttractionPart.rotation);
                    LocalRotate(bodyRotationPart, headRotationPart.localRotation);

                    continue;
                }
                
                Transform previousBodyAttractionPart = _bodyPieces[i-1].BodyAttractionPart.transform;
                Transform previousBodyRotatingPart = _bodyPieces[i-1].BodyInputRotatingPart.transform;

                SlerpMove(bodyAttractionPart.transform, previousBodyAttractionPart.position);

                LocalRotate(bodyRotationPart, previousBodyRotatingPart.rotation);
            }
        }

        private void SlerpMove(Transform movePart, Vector3 direction) => 
            movePart.position = Vector3.Slerp(movePart.position, direction, _partsSpeed * Time.deltaTime);

        private void Rotate(Transform rotatePart, Quaternion rotateTarget) =>
            rotatePart.rotation = Quaternion.Slerp(rotatePart.rotation,
                rotateTarget, _partsRotationSpeed * Time.deltaTime);
        
        private void LocalRotate(Transform rotatePart, Quaternion rotateTarget) =>
            rotatePart.localRotation = Quaternion.Slerp(rotatePart.localRotation,
                rotateTarget, _partsSpeed * Time.deltaTime);
    }
}