using UnityEngine;
public class CoinScript : MonoBehaviour
{
    private static int Score;
    void Start()
    {
        Score = 0;
    }
    private void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {           
            Destroy(gameObject);
            Score++;           
        }
        //Debug.Log("Score: " + score);       
    }

    public static int GetScore() { return Score;  }
    public static void SetScore(int NewScore) { Score = NewScore; }
}
