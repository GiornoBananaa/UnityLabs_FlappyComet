using CometSystem;
using UnityEngine;
using Zenject;

namespace CameraSystem
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _cameraTransform;
        private float _speed;

        [Inject]
        private void Construct(CometDataSO cometDataSO)
        {
            _speed = cometDataSO.XSpeed;
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
