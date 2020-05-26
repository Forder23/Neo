using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ScoreText;
    [SerializeField]
    private TMP_Text BoneText;
    private CoinScript Coins= new CoinScript();
    private ThrowBoneScript Bones = new ThrowBoneScript();
    //[SerializeField]
    //private TMP_Text TimeText;
    //[SerializeField]
    //private GameObject Player;
    void Update()
    {
        ScoreText.text = $"    {CoinScript.GetScore()}";
        BoneText.text = Bones.GetNumberOfBones().ToString();
        //TimeText.text = "Time: " + Player.GetComponent<MovementScript>().TimeSpentInGame;
    }
}
