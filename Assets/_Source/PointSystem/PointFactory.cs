using UnityEngine;
using Core;
using DataLoadingSystem;

namespace PointSystem
{
    public class PointFactory : IFactory<Point>
    {
        private readonly Point _prefab;

        public PointFactory(IRepository<ScriptableObject> dataRepository)
        {
            _prefab = dataRepository.GetItem<PointDataSO>()[0].Prefab;
        }

        public Point Create()
        {
            Point obstacle = Object.Instantiate(_prefab);
            return obstacle;
        }
    }
}