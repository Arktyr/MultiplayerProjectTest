using CodeBase.Gameplay.Services.Pool;
using CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Services.Spawners.Apples
{
    public class AppleSpawner : IAppleSpawner
    {
        private readonly GameObject _ground;
        private readonly Mesh _mesh;
        private readonly IApplePool _applePool;

        private readonly float _maximumApplesOnLevel;
        private float _distanceFromMesh;
        
        public AppleSpawner(GameObject ground, 
            IApplePool applePool,
            IStaticDataProvider staticDataProvider)
        {
            _ground = ground;
            _mesh = _ground.GetComponent<MeshFilter>().mesh;
            
            _applePool = applePool;
            
            _maximumApplesOnLevel = staticDataProvider.GameBalanceData.AppleSpawnerConfig.MaximumApplesOnLevel;
            _distanceFromMesh = staticDataProvider.GameBalanceData.AppleSpawnerConfig.DistanceFromMesh;
        }

        
        public async UniTask SpawnApples()
        {
            for (int i = 0; i < _maximumApplesOnLevel; i++) 
                await SpawnApple();
        }

        private Vector3 GetRandomPointForSpawn()
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
                return randomPoint;
            }
            
            return Vector3.zero;
        }

        private async void RespawnApple(Apple activeApple)
        {
            activeApple.PickUpped -= RespawnApple;
            
            await SpawnApple();
        }
        
        private async UniTask SpawnApple()
        {
            Apple apple = await _applePool.Take();
            apple.transform.position = GetRandomPointForSpawn();
            
            apple.PickUpped += RespawnApple;
        }
        
        private bool IsOnTexture(Vector2 uvCoord) => 
            uvCoord.x >= 0 && uvCoord.x <= 1 && uvCoord.y >= 0 && uvCoord.y <= 1;
    }
}