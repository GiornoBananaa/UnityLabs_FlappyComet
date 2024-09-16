using UnityEngine;

namespace PointSystem
{
    [CreateAssetMenu(fileName = "PointData", menuName = "SO/PointData")]
    public class PointDataSO : ScriptableObject
    {
        [field: SerializeField] public Point Prefab { get; private set; }
    }
}