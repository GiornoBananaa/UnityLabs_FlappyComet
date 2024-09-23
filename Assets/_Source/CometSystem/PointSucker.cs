using DataLoadingSystem;
using ObstacleSystem;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace CometSystem
{
    public class PointSucker : ITriggerListener, ITickable
    {
        private readonly List<(Transform, float)> _points;
        private readonly TriggerDetector _triggerDetector;
        private readonly Transform _cometTransform;
        private readonly float _suckForce;
        
        public PointSucker(TriggerDetector triggerDetector, IRepository<ScriptableObject> dataRepository)
        {
            CometDataSO data = dataRepository.GetItem<CometDataSO>()[0];
            _triggerDetector = triggerDetector;
            _cometTransform = triggerDetector.transform;
            _triggerDetector.Subscribe(this, data.PointLayers);
            _points = new List<(Transform, float)>();
            _suckForce = data.PointSuckForce;
        }
        
        public void Tick()
        {
            SuckPoint();
        }
        
        public void TriggerEnter(Collider2D other)
        {
            _points.Add((other.transform, 0));
        }
        
        private void SuckPoint()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                (Transform transform, float time) = _points[i];
                if (!transform.gameObject.activeSelf)
                {
                    _points.Remove((transform, time));
                    i--;
                    continue;
                }
                _points[i] = (transform, time += Time.deltaTime);
                transform.position = Vector2.Lerp(transform.position, _cometTransform.position, 
                    time * _suckForce / Vector2.Distance(transform.position, _cometTransform.position));
            }
        }
    }
}