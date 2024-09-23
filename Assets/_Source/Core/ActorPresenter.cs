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
    public class ActorPresenter : IStartable
    {
        readonly PointSucker _pointSucker;
        readonly PointCollector _pointCollector;
        readonly CometDeath _cometDeath;
        readonly IEnumerable<IObjectGenerator> _objectGenerators;

        public ActorPresenter(
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
    /*
    public class MainInstaller : MonoInstaller
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

        public override void InstallBindings()
        {
            //SO
            CometDataSO cometData = Resources.Load<CometDataSO>(COMET_DATA_PATH);
            Container.Bind<CometDataSO>().FromInstance(cometData).AsSingle();
            LevelGenerationDataSO levelGenerationData = Resources.Load<LevelGenerationDataSO>(LEVEL_GENERATION_DATA_PATH);
            Container.Bind<LevelGenerationDataSO>().FromInstance(levelGenerationData).AsSingle();
            ObstacleDataSO obstacleData = Resources.Load<ObstacleDataSO>(OBSTACLE_DATA_PATH);
            Container.Bind<ObstacleDataSO>().FromInstance(obstacleData).AsSingle();
            PointDataSO pointData = Resources.Load<PointDataSO>(POINT_DATA_PATH);
            Container.Bind<PointDataSO>().FromInstance(pointData).AsSingle();

            //Input
            Container.Bind<InputListener>().FromInstance(_inputListener).AsSingle();
        
            //Core
            Container.Bind<Game>().AsSingle();
            
            //Comet
            Container.Bind<CometMovement>().AsSingle().WithArguments(_comet);
            Container.Bind<CameraMovement>().FromInstance(_cameraMovement).AsSingle();
            Container.Bind<CollisionDetector>().FromInstance(_collisionDetector).AsSingle();
            Container.Bind<TriggerDetector>().FromInstance(_triggerDetector).AsSingle();
            Container.Bind<CometDeath>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PointSucker>().AsSingle().NonLazy();
            
            //Obstacle
            Container.Bind<IFactory<Obstacle>>().To<ObstacleFactory>().AsSingle();
            
            //Point
            Container.Bind<IFactory<Point>>().To<PointFactory>().AsSingle();
            Container.Bind<PointView>().FromInstance(_pointView).AsSingle();
            Container.Bind<PointCollector>().AsSingle().NonLazy();
            Container.Bind<PointContainer>().AsSingle();
            
            //Generation
            Container.Bind<GameObjectGenerator<Obstacle>>().AsSingle().NonLazy();
            Container.Bind<GameObjectGenerator<Point>>().AsSingle().NonLazy();
        }
    }*/
}