using DG.Tweening;
using UnityEngine;

namespace ObstacleSystem
{
    public class ObstacleMovement
    {
        private readonly Transform _transform;
        private Vector3[] _path;
        private Vector3 _startPosition;
        private Tween _moveTween;
        private float _speed;
        private int _pathIndex;
        
        public ObstacleMovement(Transform transform, Vector3[] path = null, float speed = 0)
        {
            _transform = transform;
            SetPath(path, speed);
        }

        public void SetPath(Vector3[] path, float speed)
        {
            _path = path;
            _speed = speed;
            _startPosition = _transform.position;
            _pathIndex = 0;
        }
        
        public void EnableMovement()
        {
            DisableMovement();
            _startPosition = _transform.position;
            if(_path != null)
                MoveToPathPoint();
        }
        
        public void DisableMovement()
        {
            _moveTween?.Kill();
        }
        
        private void MoveToPathPoint()
        {
            Vector3 pathPoint = _startPosition + _path[_pathIndex];
            
            _moveTween = _transform.DOMove(pathPoint, Vector3.Distance(_transform.position, pathPoint) / _speed).SetEase(Ease.Linear).OnComplete(MoveToPathPoint);
            _pathIndex++;
            if (_pathIndex >= _path.Length)
                _pathIndex = 0;
        }
    }
}
