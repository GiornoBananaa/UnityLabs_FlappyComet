﻿using DG.Tweening;
using ModestTree;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Zenject;

namespace CometSystem
{
    public class PointSucker : ITriggerListener, ITickable
    {
        private readonly List<(Transform, float)> _points;
        private readonly TriggerDetector _triggerDetector;
        private readonly Transform _cometTransform;
        private readonly float _suckForce;

        public PointSucker(TriggerDetector triggerDetector, CometDataSO cometData)
        {
            _triggerDetector = triggerDetector;
            _cometTransform = triggerDetector.transform;
            _triggerDetector.Subscribe(this, cometData.PointLayers);
            _points = new List<(Transform, float)>();
            _suckForce = cometData.PointSuckForce;
        }

        public void Tick()
        {
            SuckPoint();
        }

        public void TriggerEnter(Collider2D other)
        {
            _points.Add((other.attachedRigidbody.transform, 0));
        }

        public void SuckPoint()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                (Transform transform, float time)  = _points[i];
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