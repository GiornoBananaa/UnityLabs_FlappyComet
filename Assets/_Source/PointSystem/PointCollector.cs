using UnityEngine;

namespace CometSystem
{
    public class PointCollector : ICollisionListener
    {
        private readonly CollisionDetector _collisionDetector;
        private readonly PointContainer _pointContainer;

        public PointCollector(CollisionDetector collisionDetector, PointContainer pointContainer, CometDataSO cometData)
        {
            _collisionDetector = collisionDetector;
            _collisionDetector.Subscribe(this, cometData.PointLayers);
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