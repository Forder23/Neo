﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchScript : MonoBehaviour
{
    Vector3 startPoint; //place where player collides
    Vector3 endPoint; //place where player respawns
    private GameObject Neo; //player
    public bool isTouched;

    LerpHelper_Script lerp = new LerpHelper_Script();
    private void Start()
    {
        Neo = GameObject.FindGameObjectWithTag("Player");
        endPoint = Neo.GetComponent<MovementScript>().RespawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Dinosaur_Enemy")
        {
            isTouched = true;
            startPoint = transform.position;
        }
        if (collision.tag == "water")
        {
            Neo.GetComponent<Renderer>().enabled = false;
            transform.position = Neo.GetComponent<MovementScript>().RespawnPoint;
            Neo.GetComponent<Renderer>().enabled = true;
        }
    }
}