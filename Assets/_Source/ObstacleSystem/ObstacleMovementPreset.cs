using System;
using UnityEngine;

namespace ObstacleSystem
{
    [Serializable]
    public class ObstacleMovementPreset
    {
        [field: SerializeField] public Vector3[] Path { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int SpawnPriority { get; private set; }
    }
}