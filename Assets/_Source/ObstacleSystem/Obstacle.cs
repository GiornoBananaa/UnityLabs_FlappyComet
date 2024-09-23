using System;
using UnityEngine;
using VContainer;

namespace ObstacleSystem
{
    public class Obstacle : MonoBehaviour
    {
        public ObstacleMovement Movement { get; private set; }
        
        [Inject]
        public void Construct()
        {
            Movement = new ObstacleMovement(transform);
        }

        private void OnEnable()
        {
            if(Movement != null)
                Movement.EnableMovement();
        }
        
        private void OnDisable()
        {
            if(Movement != null)
                Movement.DisableMovement();
        }
    }
}