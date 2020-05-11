using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private const int NUMBER_OF_ROCKS = 6;
    [SerializeField]
    [Range(2, 5)]
    private float OffSetX;

    [SerializeField]
    private Transform PlayersHealthBox;

    [SerializeField]
    private Transform DisapperingRocksBox;

    [SerializeField]
    private List<GameObject> DisapperingRocks;

    private NeoHealthSystemScript CheckIsLifeTaken;
    void Start()
    {
        CheckIsLifeTaken = PlayersHealthBox.GetComponent<NeoHealthSystemScript>();       
        for (int i = 0; i < NUMBER_OF_ROCKS; i++)
        {
            DisapperingRocks[i].transform.position = DisapperingRocksBox.position;
            DisapperingRocks[i].transform.position = new Vector3(DisapperingRocksBox.transform.position.x + OffSetX * i, DisapperingRocksBox.transform.position.y);
            Instantiate(DisapperingRocks[i], DisapperingRocksBox, true);
            //DestroyImmediate(DisapperingRocks[i].GetComponent<BoxCollider2D>(), true);
            //DestroyImmediate(DisapperingRocks[i].GetComponent<Rigidbody2D>(),true);
        }
        CheckIsLifeTaken.SetIsLifeLost(false);
        Debug.Log($"Neo Lost Life: {CheckIsLifeTaken.GetIsLostLife()}");
    }

}
