using UnityEngine;

namespace CometSystem
{
    public interface ICollisionListener
    {
        void CollisionEnter(Collision2D other);
    }
}
