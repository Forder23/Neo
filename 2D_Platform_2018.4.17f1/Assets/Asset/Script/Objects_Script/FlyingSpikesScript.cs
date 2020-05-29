using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpikesScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private MovementScript PlayerMovement;

    [SerializeField]
    private int NumberOfSpikes;
    [SerializeField]
    private GameObject Spike;
    [SerializeField]
    private Transform Spikes_Container;
    [SerializeField]
    private int NumberOfAccumulaterSpikes;
    private List<GameObject>AccumulatedSpikes; 

    private void Start()
    {
        PlayerMovement = Player.GetComponent<MovementScript>();
    }
    private void Update()
    {       
        //Debug.Log($"OnTrigger: {PlayerMovement.GetIsOnSpikeTrigger()}");
        NumberOfSpikes = Random.Range(1, 6);
        DropSpikes(Spike, NumberOfSpikes);
    }
    private void DropSpikes(GameObject FlyingSpike, int NumberOfDeadlySpikes)
    {
        if (PlayerMovement.IsOnSpikeTrigger == true)
        {
            for (int i = 0; i < NumberOfDeadlySpikes; i++)
            {
                Instantiate(FlyingSpike, Spikes_Container.position, FlyingSpike.transform.rotation);
                NumberOfAccumulaterSpikes++;
                AccumulatedSpikes.Add(FlyingSpike);
                //foreach (var item in AccumulatedSpikes)
                //{
                //    Destroy(item, 0.5f);
                //}
            }
            PlayerMovement.IsOnSpikeTrigger = false;
        }
    }


}
