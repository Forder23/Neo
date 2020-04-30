using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    private MovementScript PlayerMovement;

    [SerializeField]
    private float RightOffset;
    [SerializeField]
    private float Speed; // this is for controlling the lerp

    private void Start()
    {
        PlayerMovement = Player.GetComponent<MovementScript>();
    }

    void Update()
    {
        if (PlayerMovement?.LookingDirection == LookingDirection.Right)
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Player.transform.position.x + RightOffset, Player.transform.position.y, -1.7f), Speed *Time.deltaTime);
            //this.transform.position = new Vector3(Player.transform.position.x + RightOffset, Player.transform.position.y + 2.3f, -1.7f);
        if (PlayerMovement?.LookingDirection == LookingDirection.Left)
            this.transform.position= Vector3.Lerp(this.transform.position, new Vector3(Player.transform.position.x - RightOffset, Player.transform.position.y, -1.7f), Speed*Time.deltaTime);
            //this.transform.position = new Vector3(Player.transform.position.x + LeftOffset, Player.transform.position.y + 2.3f, -1.7f);
    }
}
