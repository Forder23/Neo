using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    static bool playerInWater;
    Animator waterAnimator;
    SpriteRenderer waterSprite;

    GameObject Neo;
    GameObject Water;
    void Start()
    {
        playerInWater = false;
        waterAnimator = GetComponent<Animator>();
        waterSprite = GetComponent<SpriteRenderer>();

        Neo = GameObject.FindGameObjectWithTag("Player");
        Water = GameObject.FindGameObjectWithTag("WaterSprite");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            gameObject.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y-0.6f);
            waterSprite.sprite.name = "water_sprite_small_4";
            playerInWater = true;
            Destroy(gameObject,1.5f);
            //Neo.SetActive(false);
            //Neo.transform.position = Neo.GetComponent<MovementScript>().respawnPoint;
            //Neo.SetActive(true);
        }
        waterAnimator.SetBool("playerInWater", playerInWater);
        
    }

    
}
