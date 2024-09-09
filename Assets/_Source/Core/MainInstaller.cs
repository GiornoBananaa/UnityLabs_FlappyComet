using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MainInstaller : MonoInstaller
{
    private const string COMET_DATA_PATH = "CometData";

    [SerializeField] private InputListener _inputListener;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private Rigidbody2D _comet;

    public override void InstallBindings()
    {
        //SO
        CometDataSO cometData = Resources.Load<CometDataSO>(COMET_DATA_PATH);
        Container.Bind<CometDataSO>().FromInstance(cometData).AsSingle();

        //Input
        Container.Bind<InputListener>().FromInstance(_inputListener).AsSingle();

        //Comet
        Container.Bind<CometMovement>().AsSingle().WithArguments(_comet);
        Container.Bind<CameraMovement>().FromInstance(_cameraMovement).AsSingle();
        Container.Bind<CollisionDetector>().FromInstance(_collisionDetector).AsSingle();
        Container.Bind<CometDeath>().AsSingle();
    }
}