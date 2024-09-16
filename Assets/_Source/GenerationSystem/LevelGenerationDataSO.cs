using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GenerationSystem
{
    [CreateAssetMenu(fileName = "LevelGenerationData", menuName = "SO/LevelGenerationData")]
    public class LevelGenerationDataSO : ScriptableObject
    {
        [field: SerializeField] public ObjectGenerationData[] ObjectGenerationData { get; private set; }
        public Dictionary<Type, ObjectGenerationData> ObjectGenerationDataByType => _objectGenerationDataByType ??= ObjectGenerationData.ToDictionary((g)=>g.ObjectType);
        private Dictionary<Type, ObjectGenerationData> _objectGenerationDataByType;
    }
}