using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggs_Script : MonoBehaviour
{
    private const int _MAX_KEYS = 10;
    private static int CollectedEggs = 0;

    [SerializeField]
    private GameObject Player;

    private int AdditionalBones = 4;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Easter Eggs(Exploring Key found)
            Destroy(gameObject);
            CollectedEggs++;
            Player.GetComponent<ThrowBoneScript>().AddBones(AdditionalBones);
            //Debug.Log($"Easter eggs: {collectedKeys} of {_MAX_KEYS}");
            //Popup animation how many keys in collected of how many exist in game
        }
    }
}
