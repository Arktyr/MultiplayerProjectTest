using System.Collections.Generic;
using CodeBase.Gameplay.Services.Pool;
using CodeBase.Infrastructure.Factories.Apples;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Services.Spawners.Apples
{
    public class AppleSpawner : IAppleSpawner
    {
        private readonly GameObject _ground;
        private readonly Mesh _mesh;

        private readonly float _maximumApplesOnLevel;
        private readonly float _distanceFromMesh;

        private readonly IAppleFactory _appleFactory;

        private Vector3 _currentNormal;
        
        public AppleSpawner(GameObject ground,
            IAppleFactory appleFactory,
            IStaticDataProvider staticDataProvider)
        {
            _ground = ground;
            _mesh = _ground.GetComponent<MeshFilter>().mesh;

            _appleFactory = appleFactory;

            _maximumApplesOnLevel = staticDataProvider.GameBalanceData.AppleSpawnerConfig.MaximumApplesOnLevel;
            _distanceFromMesh = staticDataProvider.GameBalanceData.AppleSpawnerConfig.DistanceFromMesh;
        }

        private readonly List<Vector3> _positionOccupied = new();

        public async UniTask SpawnApples()
        {
            for (int i = 0; i < _maximumApplesOnLevel; i++) 
                await SpawnApple(await _appleFactory.Create());
        }

        private async UniTask<Vector3> GetRandomPointForSpawn()
        {
            Vector2[] uvCoordinates = _mesh.uv;
            Vector3[] normals = _mesh.normals;
            
            int randomVertexIndex = Random.Range(0, _mesh.vertices.Length);
            Vector3 randomPoint = _ground.transform.TransformPoint(_mesh.vertices[randomVertexIndex]);

            Vector2 uvCoordinate = uvCoordinates[randomVertexIndex];
            Vector3 normal = normals[randomVertexIndex];

            if (IsOnTexture(uvCoordinate))
            {
                randomPoint += normal * _distanceFromMesh;

                if (_positionOccupied.Contains(randomPoint))
                    return await GetRandomPointForSpawn();

                _currentNormal = normal;
                
                return randomPoint;
            }
            
            return Vector3.zero;
        }

        private async void RespawnApple(Apple activeApple)
        {
            activeApple.PickUpped -= RespawnApple;
            _positionOccupied.Remove(activeApple.transform.position);
            
            await SpawnApple(activeApple);
        }
        
        private async UniTask SpawnApple(Apple apple)
        {
            Transform transform = apple.transform;
            
            Vector3 randomPosition = await GetRandomPointForSpawn();

            transform.position = randomPosition;
            apple.transform.rotation = Quaternion.FromToRotation(transform.up, transform.position - _currentNormal);
            _positionOccupied.Add(randomPosition);
            
            apple.PickUpped += RespawnApple;
        }
        
        private bool IsOnTexture(Vector2 uvCoord) => 
            uvCoord.x >= 0 && uvCoord.x <= 1 && uvCoord.y >= 0 && uvCoord.y <= 1;
    }
}