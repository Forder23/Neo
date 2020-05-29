using UnityEngine;
using UnityEngine.Audio;
public class CoinScript : MonoBehaviour
{
    private static int Score=0;
    private AudioSource CoinCollectSource;    
    private void Awake()
    {
        CoinCollectSource = this.GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinCollectSource.Play();
            Destroy(this);
            gameObject.GetComponent<Renderer>().enabled = false;
            Score++;           
        }
        //Debug.Log("Score: " + score);       
    }

    public static int GetScore() { return Score;  }
    public static void SetScore(int NewScore) { Score = NewScore; }
}
