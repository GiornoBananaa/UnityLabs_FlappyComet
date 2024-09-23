using DataLoadingSystem;
using GenerationSystem;
using UnityEngine;

namespace CometSystem
{
    public class PointCollector : ICollisionListener
    {
        private readonly CollisionDetector _collisionDetector;
        private readonly PointContainer _pointContainer;

        public PointCollector(CollisionDetector collisionDetector, PointContainer pointContainer, IRepository<ScriptableObject> dataRepository)
        {
            CometDataSO data = dataRepository.GetItem<CometDataSO>()[0];
            _collisionDetector = collisionDetector;
            _collisionDetector.Subscribe(this, data.PointLayers);
            _pointContainer = pointContainer;
        }

        public void CollisionEnter(Collision2D other)
        {
            AddPoint();
            other.gameObject.SetActive(false);
        }

        private void AddPoint()
        {
            _pointContainer.AddPoint();
        }
    }
}