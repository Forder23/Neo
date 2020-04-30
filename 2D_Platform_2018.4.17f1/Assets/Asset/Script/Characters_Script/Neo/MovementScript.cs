using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookingDirection
{
    Right,
    Left
}
public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private Rigidbody2D RigidBody;
    private Animator PlayerAnimator;

    public float MovementSpeed;
    public float JumpStrength;
    public Vector3 RespawnPoint;
    public LookingDirection LookingDirection;
    public bool IsJumping;

    public event Action<float> OnAxisChanged;
    public event Action OnJumpPressed;

    [SerializeField]
    private Transform PlayerHealthBox;
    private NeoHealthSystemScript PlayerHealth;
    private void Start()
    {
        OnJumpPressed += MovementScript_OnJumpPressed;
        OnAxisChanged += MovementScript_OnAxisChanged;
        LookingDirection = LookingDirection.Right;
        RigidBody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();

        RespawnPoint = transform.position;
        IsJumping = false;

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = PlayerHealthBox.GetComponent<NeoHealthSystemScript>();
        
    }
    private void OnDestroy()
    {
        OnJumpPressed -= MovementScript_OnJumpPressed;
        OnAxisChanged -= MovementScript_OnAxisChanged;
    }

    private void MovementScript_OnJumpPressed()
    {
        RigidBody.velocity = new Vector2(RigidBody.velocity.x, JumpStrength);
        IsJumping = true;
        StartCoroutine(JumpCoolDown());
    }

    private void MovementScript_OnAxisChanged(float HorizontalAxis)
    {
        if (HorizontalAxis > 0)
        {
            MovementSpeed = 5f;
            LookingDirection = LookingDirection.Right;
            if (LookingDirection == LookingDirection.Right)
            {
                transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }           
        if (HorizontalAxis < 0)
        {
            MovementSpeed = 5f;
            LookingDirection = LookingDirection.Left;
            if (LookingDirection == LookingDirection.Left)
            {
                transform.localRotation = new Quaternion(0, -180, 0,0);
            }            
        }
        if (HorizontalAxis == 0)
            MovementSpeed = 0f;
        
        //Debug.Log("Player looking to the  " + LookingDirection);

        RigidBody.velocity = new Vector2(HorizontalAxis * MovementSpeed, RigidBody.velocity.y);
    }

    private void Update()
    {
        OnAxisChanged?.Invoke(Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Jump"))
            OnJumpPressed?.Invoke();

        PlayerAnimator.SetFloat("movementSpeed", MovementSpeed);
        PlayerAnimator.SetBool("IsJumping", IsJumping);
    }

    private IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(0.6f);
        IsJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Dinosaur_Enemy"))
        {
            PlayerHealth.TakeLife(); //take one life
            //animation for hurt player
            //save position before hurt and start from that position or from the last checkpoint           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                //Debug.Log("You're on the platform");
                Player.transform.parent = collision.transform;
            }
        }
        else
        {
            Debug.Log("Null reference");
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision!= null)
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                Player.transform.parent = null;
                //Debug.Log("You left the platform");
            }
        }
    }
}

