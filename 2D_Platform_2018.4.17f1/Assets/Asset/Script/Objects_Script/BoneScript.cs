using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScript : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody2D rb;
    [SerializeField]
    private GameObject bloodObject;
    GameObject bloodObjectToDestroy;

    public LookingDirection Direction;

    float boneDamage = 0.2f;

    private void Start()
    {
        if(Direction == LookingDirection.Right)
            rb.velocity = transform.right * Speed;
        else
            rb.velocity = -transform.right * Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamagerScript damage = collision.GetComponent<DamagerScript>();
        if (collision.tag=="Dinosaur_Enemy")
        {
            damage.MakeDamage(boneDamage);
            bloodObjectToDestroy = Instantiate(bloodObject, transform.position, bloodObject.transform.rotation);
            Destroy(gameObject);
        }
        Destroy(bloodObjectToDestroy, 0.3f);
    }
}
