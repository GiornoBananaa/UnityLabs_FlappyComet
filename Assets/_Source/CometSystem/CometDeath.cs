using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometDeath : ICollisionListener
{
    private CollisionDetector _collisionDetector;

    public CometDeath(CollisionDetector collisionDetector, LayerMask deathLayer, LayerMask pointLayer)
    {
        _collisionDetector = collisionDetector;
        _collisionDetector.Subscribe(this, deathLayer);
    }

    public void CollisionEnter(Collision other)
    {
        
    }
}
 