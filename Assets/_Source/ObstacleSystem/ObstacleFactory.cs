using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ObstacleSystem
{
    public class ObstacleFactory : IFactory<Obstacle>
    {
        private readonly ObstacleMovementPreset[] _movementPresets;
        private readonly Obstacle _prefab;
        
        public ObstacleFactory(ObstacleDataSO obstacleData)
        {
            _prefab = obstacleData.Prefab;
            _movementPresets = obstacleData.MovementPresets;
        }
        
        public Obstacle Create()
        {
            Obstacle obstacle = Object.Instantiate(_prefab);
            obstacle.gameObject.SetActive(false);
            obstacle.Construct();
            ObstacleMovementPreset rndPreset = _movementPresets[0];
            float prioritySum = 0;
            foreach (var movementPreset in _movementPresets)
            {
                prioritySum += movementPreset.SpawnPriority;
            }
            
            float rndPriority = Random.Range(0, prioritySum);
            float priorityBuf = 0;
            foreach (var movementPreset in _movementPresets)
            {
                priorityBuf += movementPreset.SpawnPriority;
                if (priorityBuf > rndPriority)
                {
                    rndPreset = _movementPresets[Random.Range(0, _movementPresets.Length)];
                }
            }
            obstacle.Movement.SetPath(rndPreset.Path, rndPreset.Speed);
            return obstacle;
        }
    }
}