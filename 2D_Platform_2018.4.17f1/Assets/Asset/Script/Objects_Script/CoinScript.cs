using UnityEngine;
public class CoinScript : MonoBehaviour
{
    private static int score;
    void Start()
    {
        score = 0;
    }
    private void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {           
            Destroy(gameObject);
            score++;           
        }
        //Debug.Log("Score: " + score);       
    }

    public int GetScore() { return score;  }
}
