using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometMovement
{
    private Rigidbody2D _rigidBody;
    private float _acceliration;
    private float _maxVelocity;

    public CometMovement(Rigidbody2D comet, CometDataSO cometData)
    {
        _rigidBody = comet;
        _acceliration = cometData.YAcceliration;
        _maxVelocity = cometData.YMaxVelocity;
    }

    public void LiftComet()
    {
        _rigidBody.AddForce(Vector2.up * _acceliration, ForceMode2D.Force);
        
        if (_rigidBody.velocity.y > _maxVelocity)
            _rigidBody.velocity = Vector2.up * _maxVelocity;
        else if (_rigidBody.velocity.y < -_maxVelocity)
            _rigidBody.velocity = Vector2.up * -_maxVelocity;
    }
}
