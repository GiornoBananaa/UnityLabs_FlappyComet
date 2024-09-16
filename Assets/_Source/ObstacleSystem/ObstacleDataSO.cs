using UnityEngine;

namespace ObstacleSystem
{
    [CreateAssetMenu(fileName = "ObstacleData", menuName = "SO/ObstacleData")]
    public class ObstacleDataSO : ScriptableObject
    {
        [field: SerializeField] public Obstacle Prefab { get; private set; }
        [field: SerializeField] public ObstacleMovementPreset[] MovementPresets { get; private set; }
    }
}