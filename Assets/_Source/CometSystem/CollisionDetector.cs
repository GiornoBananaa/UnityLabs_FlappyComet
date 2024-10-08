using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace CometSystem
{
    public class CollisionDetector : MonoBehaviour
    {
        private readonly Dictionary<ICollisionListener, LayerMask> _collisionListener = new();

        public void Subscribe(ICollisionListener listener, LayerMask layerMask)
        {
            _collisionListener.Add(listener, layerMask);
        }

        public void Subscribe(ICollisionListener listener)
        {
            _collisionListener.Add(listener, Physics.AllLayers);
        }

        public void UnSubscribe(ICollisionListener listener)
        {
            _collisionListener.Remove(listener);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            foreach (var listener in _collisionListener)
            {
                if (listener.Value.Contains(other.gameObject.layer))
                {
                    listener.Key.CollisionEnter(other);
                }
            }
        }
    }
}
