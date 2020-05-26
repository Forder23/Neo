using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript : MonoBehaviour
{
    [SerializeField]
    [Range(1.5f,3.5f)]
    private float EnemySpeed;

    [SerializeField]
    [Range(1.5f, 3.5f)]
    private float Distance;

    [SerializeField]
    private Transform Checker;    
    
    private bool MovingRight;
    private void Start()
    {
        EnemySpeed = 4.2f; 
        Distance = 2.4f;
    }
    void Update()
    {
        transform.Translate(-Vector2.right * EnemySpeed *Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(Checker.position, Vector2.down, Distance);

        if (groundCheck.collider == false)
        {
            if (MovingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }
        }
    }
}
