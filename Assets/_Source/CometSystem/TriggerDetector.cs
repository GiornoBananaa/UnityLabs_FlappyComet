using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace CometSystem
{
    public class TriggerDetector : MonoBehaviour
    {
        private readonly Dictionary<ITriggerListener, LayerMask> _triggerListener = new();

        public void Subscribe(ITriggerListener listener, LayerMask layerMask)
        {
            _triggerListener.Add(listener, layerMask);
        }

        public void Subscribe(ITriggerListener listener)
        {
            _triggerListener.Add(listener, Physics.AllLayers);
        }

        public void UnSubscribe(ITriggerListener listener)
        {
            _triggerListener.Remove(listener);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var listener in _triggerListener)
            {
                if (listener.Value.Contains(other.gameObject.layer))
                {
                    listener.Key.TriggerEnter(other);
                }
            }
        }
    }
}
