using UnityEngine;
using Zenject;

namespace PointSystem
{
    public class PointFactory : IFactory<Point>
    {
        private readonly Point _prefab;

        public PointFactory(PointDataSO pointData)
        {
            _prefab = pointData.Prefab;
        }

        public Point Create()
        {
            Point obstacle = Object.Instantiate(_prefab);
            return obstacle;
        }
    }
}