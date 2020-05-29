using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystemScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private ThrowBoneScript PlayerThrow;
    private MovementScript PlayerMovement;
    private NeoHealthSystemScript PlayerHealth;

    public void Start()
    {
        PlayerThrow = Player.GetComponent<ThrowBoneScript>();
        //HeartBox = GameObject.FindGameObjectWithTag("HeartBox");
        PlayerMovement = Player.GetComponent<MovementScript>();
        PlayerHealth = PlayerMovement.GetComponent<NeoHealthSystemScript>();
    }
    public void SaveData()
    {
        int CurrentScore = CoinScript.GetScore();
        //int CurrentBones = PlayerThrow.GetNumberOfBones();
        //Debug.Log($"Bones: {CurrentBones}");
        int CurrentEggs = EasterEggs_Script.GetEasterEggs();
        int CurrentHealth = NeoHealthSystemScript.GetNumberOfCurrentLifes();
        float Timer = Player.GetComponent<MovementScript>().GetTime();
        //Debug.Log($"Current Health : {CurrentHealth}");
        PlayerPrefs.SetInt("Score", CurrentScore);
        //PlayerPrefs.SetInt("Bones", CurrentBones);
        PlayerPrefs.SetInt("Health", CurrentHealth);
        PlayerPrefs.SetInt("Eggs", CurrentEggs);
        PlayerPrefs.SetFloat("Timer", Timer);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        CoinScript.SetScore(PlayerPrefs.GetInt("Score"));
        //PlayerThrow.SetNumberOfBones(PlayerPrefs.GetInt("Bones"));
        NeoHealthSystemScript.SetNumberOfCurrentLifes(PlayerPrefs.GetInt("Health"));
        Player.GetComponent<MovementScript>().SetTime(PlayerPrefs.GetFloat("Timer"));
        EasterEggs_Script.SetEasterEggs(PlayerPrefs.GetInt("Eggs"));
    }


}
