using UnityEngine;

namespace CometSystem
{
    public class CometMovement
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly float _acceleration;
        private readonly float _maxVelocity;

        public CometMovement(Rigidbody2D comet, CometDataSO cometData)
        {
            _rigidBody = comet;
            _acceleration = cometData.YAcceleration;
            _maxVelocity = cometData.YMaxVelocity;
        }

        public void LiftComet()
        {
            _rigidBody.AddForce(Vector2.up * _acceleration, ForceMode2D.Force);
            
            if (_rigidBody.velocity.y > _maxVelocity)
                _rigidBody.velocity = Vector2.up * _maxVelocity;
            else if (_rigidBody.velocity.y < -_maxVelocity)
                _rigidBody.velocity = Vector2.up * -_maxVelocity;
        }
    }
}
