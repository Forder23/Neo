using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper_Script : MonoBehaviour
{
    public GameObject Neo;
    [SerializeField]
    [Range(0, 3)]
    float lerpSpeed;
    public bool moving = false;
    EnemyTouchScript enemy;
    void Start()
    {
        Neo = GameObject.FindGameObjectWithTag("Player");
        Neo.GetComponent<MovementScript>().RespawnPoint = Neo.transform.position;
        enemy = Neo.GetComponent<EnemyTouchScript>();
    }

    private void Update()
    {
        if (enemy.isTouched == true)
        {
            moving = true;
            Neo.GetComponent<Renderer>().enabled = false;
        }

        if (moving == true)
        {

            Neo.transform.position = Vector3.Lerp(Neo.transform.position, Neo.GetComponent<MovementScript>().RespawnPoint, lerpSpeed * Time.deltaTime);
        }

        float distBetween = Vector3.Distance(Neo.transform.position, Neo.GetComponent<MovementScript>().RespawnPoint);

        if (distBetween <= 0.3)
        {
            enemy.isTouched = false;
            moving = false;
            Neo.GetComponent<Renderer>().enabled = true;
            Neo.GetComponent<MovementScript>().SetHurt(false);
        }
    }
}