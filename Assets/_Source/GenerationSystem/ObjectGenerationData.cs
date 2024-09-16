using System;
using ObstacleSystem;
using PointSystem;
using UnityEngine;

namespace GenerationSystem
{
    [Serializable]
    public class ObjectGenerationData
    {
        [SerializeField] private LevelObject _levelObject;
        [field: SerializeField] public float SpawnTimeGap { get; private set; }
        [field: SerializeField] public float SpawnTimeGapSpread { get; private set; }
        [field: SerializeField] public float LifeTime { get; private set; }

        public Type ObjectType
        {
            get
            {
                return _levelObject switch
                {
                    LevelObject.Obstacle => typeof(Obstacle),
                    LevelObject.Point => typeof(Point),
                    _ => null
                };
            }
        }
    }
}