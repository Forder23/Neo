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

    private int CoinsCollected;
    private int EasterEggsCollected;
    private int UnusedBones;
    private int LifesSaved;
    private int DeathDinosaurus;

    private void Start()
    {
        PickedCoins.text = $"Coins: {CoinsCollected}";
        PickedCoins.color= Color.white;
        PickedEasterEggs.text = $"Easter eggs: {EasterEggsCollected}";
        LeftBones.text = $"Left bones: {UnusedBones}";
        LeftLifes.text = $"Lifes: {LifesSaved}";
        KilledDinosaurus.text = $"Kills: {DeathDinosaurus}";
    }
}
