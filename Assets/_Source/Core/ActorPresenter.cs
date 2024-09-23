using CameraSystem;
using CometSystem;
using GenerationSystem;
using InputSystem;
using ObstacleSystem;
using PointSystem;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : IStartable
    {
        readonly PointSucker _pointSucker;
        readonly PointCollector _pointCollector;
        readonly CometDeath _cometDeath;
        readonly IEnumerable<IObjectGenerator> _objectGenerators;

        public Bootstrapper(
            PointCollector pointCollector,
            PointSucker pointSucker,
            CometDeath cometDeath,
            IEnumerable<IObjectGenerator> objectGenerators)
        {
            _pointCollector = pointCollector;
            _pointSucker = pointSucker;
            _objectGenerators = objectGenerators;
            _cometDeath = cometDeath;
        }

        void IStartable.Start()
        {
            foreach (IObjectGenerator objectGenerator in _objectGenerators)
            {
                objectGenerator.EnableGeneration();
            }
        }
    }
}