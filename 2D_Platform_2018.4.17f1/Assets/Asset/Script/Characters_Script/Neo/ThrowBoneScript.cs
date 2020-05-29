using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowBoneScript : MonoBehaviour
{
    private const int _NUMBER_OF_BONES_IN_BUNCH = 6;

    private static int NumberOfBones=0;

    public Transform FirePoint;
    public GameObject BonePrefab;

    [SerializeField]
    private TMP_Text textBones;
    private MovementScript PlayerMovement;

    public AudioSource GetBonesAudio;

    void Start()
    {
        PlayerMovement = GetComponent<MovementScript>();
        GetBonesAudio = PlayerMovement.NoBonesSource;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CheckNumberOfBones();
        }

    }

    public void AddBones(int bones)
    {
        NumberOfBones += bones;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Bunch_Bones"))
            {
                AddBones(_NUMBER_OF_BONES_IN_BUNCH);
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Debug.Log("Bunch_Bone is nulled");
        }

    }
    public int GetNumberOfBones() { return NumberOfBones; }
    public void SetNumberOfBones(int NewBones) { NumberOfBones = NewBones; }

    void Shoot()
    {
        var InstantiateBone = Instantiate(BonePrefab, FirePoint.position, Quaternion.identity);
        InstantiateBone.GetComponent<BoneScript>().Direction = PlayerMovement.LookingDirection;
    }
    void CheckNumberOfBones()
    {
        if (NumberOfBones > 0)
        {
            Shoot();
            NumberOfBones--;
        }
        if ((Input.GetButtonDown("Fire1")) && (NumberOfBones == 0))
        {
            StartCoroutine(CooldownForAlert());
            GetBonesAudio.Play();
        }
    }
    IEnumerator CooldownForAlert()
    {
        textBones.enabled = true;
        textBones.text = "No bones to shoot!!";
        yield return new WaitForSeconds(.25f);
        textBones.enabled = false;
    }

}