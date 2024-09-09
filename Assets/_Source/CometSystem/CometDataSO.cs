using UnityEngine;

[CreateAssetMenu(menuName = "SO/CometData", fileName = "CometData")]
public class CometDataSO : ScriptableObject
{
    [field: SerializeField] public float XSpeed { get; private set; }
    [field: SerializeField] public float YAcceliration { get; private set; }
    [field: SerializeField] public float YMaxVelocity { get; private set; }
    [field: SerializeField] public LayerMask DeathLayers { get; private set; }
    [field: SerializeField] public LayerMask PointLayers { get; private set; }
}