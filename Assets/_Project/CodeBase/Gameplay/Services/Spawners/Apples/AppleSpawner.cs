using System.Collections.Generic;
using _Project.CodeBase.Gameplay.Apples;
using _Project.CodeBase.Infrastructure.Factories.Apples;
using _Project.CodeBase.Infrastructure.Services.Providers.StaticDataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.CodeBase.Gameplay.Services.Spawners.Apples
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
            Vector3[] vertices = _mesh.vertices;
            
            Vector3 randomVertex = vertices[Random.Range(0, vertices.Length)];
            Vector3 randomPoint = _ground.transform.TransformPoint(randomVertex);
            
            Vector3 offset = randomPoint * _distanceFromMesh;
            Vector3 finalPoint = randomPoint + offset;

            if (_positionOccupied.Contains(finalPoint))
                return await GetRandomPointForSpawn();

            _currentNormal = (finalPoint - _ground.transform.position).normalized;
            
            _positionOccupied.Add(finalPoint);
            return finalPoint;
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
            apple.transform.rotation = Quaternion.FromToRotation(Vector3.up, _currentNormal);
            _positionOccupied.Add(randomPosition);
            apple.gameObject.SetActive(true);
            
            apple.PickUpped += RespawnApple;
        }
    }
}