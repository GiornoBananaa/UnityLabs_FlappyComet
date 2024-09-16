using UnityEngine;

namespace CometSystem
{
    public interface ITriggerListener
    {
        void TriggerEnter(Collider2D other);
    }
}
