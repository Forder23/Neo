using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchScript : MonoBehaviour
{
    Vector3 StartPoint; //place where player collides
    Vector3 EndPoint; //place where player respawns
    private GameObject Neo; //player
    public bool IsTouched;

    LerpHelper_Script lerp;
    private void Start()
    {
        Neo = GameObject.FindGameObjectWithTag("Player");
        EndPoint = Neo.GetComponent<MovementScript>().RespawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Dinosaur_Enemy" || collision.tag == "Dinosaur_Enemy_02")
        {
            IsTouched = true;
            StartPoint = transform.position;
        }
        if (collision.tag == "water")
        {
            Neo.GetComponent<Renderer>().enabled = false;
            transform.position = Neo.GetComponent<MovementScript>().RespawnPoint;
            Neo.GetComponent<Renderer>().enabled = true;
        }
    }
}