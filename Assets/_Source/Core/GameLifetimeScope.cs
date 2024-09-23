using CameraSystem;
using CometSystem;
using Core;
using GenerationSystem;
using InputSystem;
using ObstacleSystem;
using PointSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using VContainer;

namespace Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        private const string COMET_DATA_PATH = "CometData";
        private const string LEVEL_GENERATION_DATA_PATH = "LevelGenerationData";
        private const string OBSTACLE_DATA_PATH = "ObstacleData";
        private const string POINT_DATA_PATH = "PointData";

        [SerializeField] private InputListener _inputListener;
        [SerializeField] private CameraMovement _cameraMovement;
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private TriggerDetector _triggerDetector;
        [SerializeField] private Rigidbody2D _comet;
        [SerializeField] private PointView _pointView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ActorPresenter>();

            //SO
            CometDataSO cometData = Resources.Load<CometDataSO>(COMET_DATA_PATH);
            builder.RegisterInstance<CometDataSO>(cometData);
            LevelGenerationDataSO levelGenerationData = Resources.Load<LevelGenerationDataSO>(LEVEL_GENERATION_DATA_PATH);
            builder.RegisterInstance<LevelGenerationDataSO>(levelGenerationData);
            ObstacleDataSO obstacleData = Resources.Load<ObstacleDataSO>(OBSTACLE_DATA_PATH);
            builder.RegisterInstance<ObstacleDataSO>(obstacleData);
            PointDataSO pointData = Resources.Load<PointDataSO>(POINT_DATA_PATH);
            builder.RegisterInstance<PointDataSO>(pointData);

            //Input
            builder.RegisterComponent<InputListener>(_inputListener);

            //Core
            builder.Register<Game>(Lifetime.Singleton);

            //Comet
            builder.RegisterComponent<TriggerDetector>(_triggerDetector);
            builder.RegisterComponent<CollisionDetector>(_collisionDetector);
            builder.RegisterComponent<CameraMovement>(_cameraMovement);
            builder.Register<CometMovement>(Lifetime.Singleton).WithParameter(_comet);
            builder.Register<PointSucker>(Lifetime.Singleton);
            builder.Register<ITickable, PointSucker>(Lifetime.Singleton);
            builder.Register<CometDeath>(Lifetime.Singleton);

            //Obstacle
            builder.Register<IFactory<Obstacle>, ObstacleFactory>(Lifetime.Singleton);

            //Point
            builder.Register<IFactory<Point>, PointFactory>(Lifetime.Singleton);
            builder.RegisterComponent<PointView>(_pointView);
            builder.Register<PointCollector>(Lifetime.Singleton);
            builder.Register<PointContainer>(Lifetime.Singleton);

            //Generation
            builder.Register<IObjectGenerator, GameObjectGenerator<Obstacle>>(Lifetime.Singleton);
            builder.Register<IObjectGenerator, GameObjectGenerator<Point>>(Lifetime.Singleton);
        }
    }
}