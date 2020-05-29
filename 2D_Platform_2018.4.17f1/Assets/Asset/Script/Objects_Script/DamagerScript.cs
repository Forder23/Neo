﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerScript : MonoBehaviour
{
    private int Kills;
    [SerializeField]
    float health=.99f;

    public GameObject hp;
    public GameObject HealthBar;
    private AudioSource DeathSound;
    private bool IsDead = false;
    private void Start()
    {
        Debug.Log("HP: " + health);
        hp.GetComponent<HealthScript>().SetMaxHealth(health);
        HealthBar = GameObject.FindGameObjectWithTag("Dinosaur_Enemy");
        DeathSound = gameObject.GetComponent<AudioSource>();
    }
    public void MakeDamage(float damage)
    {
        if (health-damage*2 <= 0)
        {
            DeathSound.Play();
            Destroy(gameObject);
            //Debug.Log("Killed enemy");
            //Animation for kills
            //Destroying object
            //Appearing bunch of bones as reward and coins..
            //Increased number of the killed enemies
        }
        else
        {
            health -= damage;
            Debug.Log($"Enemy health: {health}" + "with name : " + this.gameObject.name);
            hp.GetComponent<HealthScript>().SetCurrentHealth(health);
        }
    }
}
