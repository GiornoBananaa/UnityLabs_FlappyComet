using Core;
using UnityEngine;

namespace CometSystem
{
    public class CometDeath : ICollisionListener
    {
        private readonly CollisionDetector _collisionDetector;
        private readonly Game _game;

        public CometDeath(CollisionDetector collisionDetector, Game game, CometDataSO cometData)
        {
            _collisionDetector = collisionDetector;
            _collisionDetector.Subscribe(this, cometData.DeathLayers);
            _game = game;
        }

        public void CollisionEnter(Collision2D other)
        {
            _game.Restart();
        }
    }
}