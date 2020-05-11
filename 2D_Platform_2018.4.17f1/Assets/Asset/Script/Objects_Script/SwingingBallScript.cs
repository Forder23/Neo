using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingBallScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RigidBody;
    [SerializeField]
    private float LeftPush;
    [SerializeField]
    private float RightPush;
    [SerializeField]
    private float Velocity;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.angularVelocity = Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    private void Push()
    {
        if ((transform.rotation.z > 0) && (transform.rotation.z < RightPush) && (RigidBody.angularVelocity > 0) &&
            (RigidBody.angularVelocity < Velocity))
         {
            RigidBody.angularVelocity = Velocity;
            
         }
        else if ((transform.rotation.z < 0) && (transform.rotation.z > LeftPush) && (RigidBody.angularVelocity < 0) &&
            (RigidBody.angularVelocity > Velocity * -1))
        {
            RigidBody.angularVelocity = Velocity * -1;
        }
    }
}
