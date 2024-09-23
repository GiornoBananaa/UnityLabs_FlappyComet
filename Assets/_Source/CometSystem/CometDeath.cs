using Core;
using DataLoadingSystem;
using UnityEngine;

namespace CometSystem
{
    public class CometDeath : ICollisionListener
    {
        private readonly CollisionDetector _collisionDetector;
        private readonly Game _game;

        public CometDeath(CollisionDetector collisionDetector, Game game, IRepository<ScriptableObject> dataRepository)
        {
            CometDataSO data = dataRepository.GetItem<CometDataSO>()[0];
            _collisionDetector = collisionDetector;
            _collisionDetector.Subscribe(this, data.DeathLayers);
            _game = game;
        }

        public void CollisionEnter(Collision2D other)
        {
            _game.Restart();
        }
    }
}