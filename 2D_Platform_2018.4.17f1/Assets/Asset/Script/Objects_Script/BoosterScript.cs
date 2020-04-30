using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Neo;

    private const float  _BOOSTER_DURATION = 1.5f;
    private void Start()
    {
        Neo = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        MovementScript playerJump = Neo.GetComponent<MovementScript>();
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            Neo.GetComponent<MovementScript>().JumpStrength = 10f;
            //Debug.Log("Coroutine Started");
            yield return new WaitForSeconds(_BOOSTER_DURATION);
            //Debug.Log("Coroutine Ended");
            Neo.GetComponent<MovementScript>().JumpStrength = 6.0f;
            Destroy(gameObject);
        }
    }
}
