using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoorScript : MonoBehaviour
{
    [SerializeField]
    private bool IsTriggered = false;
    [SerializeField]
    private GameObject MovingDoor;
    [SerializeField]
    private Vector2 FinalPosition;

    [SerializeField]
    [Range(1,10)]
    private float MovementSpeed;

    void Update()
    {
        if (IsTriggered == true)
        {
            MovingDoor.transform.position += new Vector3(0, MovementSpeed * Time.deltaTime, 0);
            Debug.Log(Mathf.Abs(MovingDoor.transform.position.y - FinalPosition.y));
            if (Mathf.Abs(MovingDoor.transform.position.y - FinalPosition.y) <= 0.15f)
            {
                IsTriggered = false;
                if (IsTriggered == false)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsTriggered = true;
                Debug.Log($"Doors are: {IsTriggered}");
            }
        }
    }
}
