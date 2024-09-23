using CometSystem;
using DataLoadingSystem;
using PointSystem;
using UnityEngine;
using VContainer;

namespace CameraSystem
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _cameraTransform;
        private float _speed;

        [Inject]
        private void Construct(IRepository<ScriptableObject> dataRepository)
        {
            _speed = dataRepository.GetItem<CometDataSO>()[0].XSpeed;
        }

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _cameraTransform.position += Vector3.right * (_speed * Time.deltaTime);
        }
    }
}
