using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerScript : MonoBehaviour
{
    [SerializeField]
    float health=.99f;

    public GameObject hp;
    private void Start()
    {
        Debug.Log("HP: " + health);
        hp.GetComponent<HealthScript>().SetMaxHealth(health);
    }
    public void MakeDamage(float damage)
    {
        if (health-damage*2 <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Killed enemy");
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
