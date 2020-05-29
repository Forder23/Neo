using System;
using TMPro;
using UnityEngine;

public class FinalResultsScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text PickedCoins;
    [SerializeField]
    private TMP_Text PickedEasterEggs;
    [SerializeField]
    private TMP_Text LeftBones;
    [SerializeField]
    private TMP_Text LeftLifes;
    [SerializeField]
    private TMP_Text KilledDinosaurus;

    [SerializeField]
    private TMP_Text Timer;

    [SerializeField]
    private GameObject Player;

    private int CoinsCollected;
    private int UnusedBones;
    private int EasterEggsCollected;   
    private int LifesSaved;
    private int DeathDinosaurus;
    private float TimeInGame;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CoinsCollected = CoinScript.GetScore();
        EasterEggsCollected = EasterEggs_Script.GetEasterEggs();
        UnusedBones = Player.GetComponent<ThrowBoneScript>().GetNumberOfBones();
        LifesSaved = NeoHealthSystemScript.GetNumberOfCurrentLifes();

        TimeInGame = MovementScript.TimeSpentInGame;
        PickedCoins.text = $"Coins: {CoinsCollected}";
        LeftBones.text = $"Left bones: {UnusedBones}";

        PickedEasterEggs.text = $"Easter eggs: {EasterEggsCollected}";        
        LeftLifes.text = $"Lifes: {LifesSaved}";
        KilledDinosaurus.text = $"Kills: {DeathDinosaurus}";
        Timer.text = $"Time: {TimeInGame}";
        
    }
}
