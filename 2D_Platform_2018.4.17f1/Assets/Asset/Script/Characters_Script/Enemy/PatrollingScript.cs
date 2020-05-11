using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript : MonoBehaviour
{
    float enemySpeed;
    float distance;
    public Transform checker;    
    bool movingRight;
    private void Start()
    {
        enemySpeed = 4.2f; 
        distance = 2.4f;
    }
    void Update()
    {
        transform.Translate(-Vector2.right * enemySpeed *Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(checker.position, Vector2.down, distance);

        if (groundCheck.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
