using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Characters
{
    public class CharacterBody : MonoBehaviour
    {
        [SerializeField] private BodyParts _headParts;

        private readonly List<BodyParts> _bodyPieces = new();

        public void AddBodyPiece(BodyParts bodyParts) => 
            _bodyPieces.Add(bodyParts);
        
        public void ShiftPieces()
        {
            if (_bodyPieces.Count == 0)
                return;
            
            for (int i = 0; i < _bodyPieces.Count; i++)
            {
                if (i == 0)
                {
                    SlerpMove(_bodyPieces[i].BodyAttractionPart.transform,
                        _headParts.BodyAttractionPart.transform.position, 12);

                    Rotate(_bodyPieces[i].BodyAttractionPart.transform, _headParts.BodyAttractionPart.rotation, 10);
                  
                    LocalRotate(_bodyPieces[i].BodyInputRotatingPart, _headParts.BodyInputRotatingPart.localRotation, 10);

                    continue;
                }

                SlerpMove(_bodyPieces[i].BodyAttractionPart.transform,
                    _bodyPieces[i-1].BodyAttractionPart.position, 6);

                LocalRotate(_bodyPieces[i].BodyInputRotatingPart, _bodyPieces[i-1].BodyInputRotatingPart.rotation, 10);
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