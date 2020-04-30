using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ScoreText;
    [SerializeField]
    private TMP_Text BoneText;
    private CoinScript Coins = new CoinScript();
    private ThrowBoneScript Bones = new ThrowBoneScript();
    void Update()
    {
        ScoreText.text = "    " + Coins.GetScore().ToString();
        BoneText.text = Bones.GetNumberOfBones().ToString();
    }
}
