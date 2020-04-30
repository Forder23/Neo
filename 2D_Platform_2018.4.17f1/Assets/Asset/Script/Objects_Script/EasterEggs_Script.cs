using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggs_Script : MonoBehaviour
{
    private const int _MAX_KEYS = 10;
    private static int collectedKeys = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Easter Eggs(Exploring Key found)
            Destroy(gameObject);
            collectedKeys++;
            //Debug.Log($"Easter eggs: {collectedKeys} of {_MAX_KEYS}");
            //Popup animation how many keys in collected of how many exist in game
        }
    }
}
