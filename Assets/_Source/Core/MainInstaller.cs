using CameraSystem;
using CometSystem;
using GenerationSystem;
using InputSystem;
using ObstacleSystem;
using PointSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        private const string COMET_DATA_PATH = "CometData";
        private const string LEVEL_GENERATION_DATA_PATH = "LevelGenerationData";
        private const string OBSTACLE_DATA_PATH = "ObstacleData";
        private const string POINT_DATA_PATH = "PointData";

        [SerializeField] private InputListener _inputListener;
        [SerializeField] private CameraMovement _cameraMovement;
        [SerializeField] private CollisionDetector _collisionDetector;
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
            Container.Bind<CometDeath>().AsSingle().NonLazy();
            
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
    }
}