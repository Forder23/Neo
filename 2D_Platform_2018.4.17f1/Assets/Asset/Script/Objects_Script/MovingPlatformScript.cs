using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField]
    private Transform StartForPlatform;
    [SerializeField]
    private Transform EndForPlatform;
    [SerializeField]
    [Range(1, 6)]
    private float SpeedForMoving;

    [SerializeField]
    private Transform StartPosition;
    private Vector3 NextPosition;
    void Start()
    {
        NextPosition = StartPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == StartForPlatform.position)
        {
            NextPosition = EndForPlatform.position;
        }
        if (transform.position == EndForPlatform.position)
        {
            NextPosition = StartForPlatform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, NextPosition, SpeedForMoving * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(StartForPlatform.position, EndForPlatform.position);
    }
}
