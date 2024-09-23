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
using DataLoadingSystem;

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
            builder.RegisterEntryPoint<Bootstrapper>();

            #region DataLoad
            IResourceLoader resourceLoader = new ResourceLoader();
            IRepository<ScriptableObject> dataRepository = new DataRepository<ScriptableObject>();

            LoadResources(resourceLoader, dataRepository);

            builder.RegisterInstance<IRepository<ScriptableObject>>(dataRepository);
            #endregion

            #region Input
            builder.RegisterComponent<InputListener>(_inputListener);
            #endregion

            #region Core
            builder.Register<Game>(Lifetime.Singleton);
            #endregion

            #region Comet
            builder.RegisterComponent<TriggerDetector>(_triggerDetector);
            builder.RegisterComponent<CollisionDetector>(_collisionDetector);
            builder.RegisterComponent<CameraMovement>(_cameraMovement);
            builder.Register<CometMovement>(Lifetime.Singleton).WithParameter(_comet);
            builder.Register<PointSucker>(Lifetime.Singleton);
            builder.Register<ITickable, PointSucker>(Lifetime.Singleton);
            builder.Register<CometDeath>(Lifetime.Singleton);
            #endregion

            #region Obstacle
            builder.Register<IFactory<Obstacle>, ObstacleFactory>(Lifetime.Singleton);
            #endregion

            #region Point
            builder.Register<IFactory<Point>, PointFactory>(Lifetime.Singleton);
            builder.RegisterComponent<PointView>(_pointView);
            builder.Register<PointCollector>(Lifetime.Singleton);
            builder.Register<PointContainer>(Lifetime.Singleton);
            #endregion

            #region Generation
            builder.Register<IObjectGenerator, GameObjectGenerator<Obstacle>>(Lifetime.Singleton);
            builder.Register<IObjectGenerator, GameObjectGenerator<Point>>(Lifetime.Singleton);
            #endregion
        }

        private void LoadResources(IResourceLoader resourceLoader, IRepository<ScriptableObject> dataRepository)
        {
            resourceLoader.LoadResource(PathData.LEVEL_GENERATION_DATA_PATH,
              typeof(LevelGenerationDataSO), dataRepository);
            resourceLoader.LoadResource(PathData.POINT_DATA_PATH,
              typeof(PointDataSO), dataRepository);
            resourceLoader.LoadResource(PathData.COMET_DATA_PATH,
              typeof(CometDataSO), dataRepository);
            resourceLoader.LoadResource(PathData.OBSTACLE_DATA_PATH,
              typeof(ObstacleDataSO), dataRepository);
        }
    }
}