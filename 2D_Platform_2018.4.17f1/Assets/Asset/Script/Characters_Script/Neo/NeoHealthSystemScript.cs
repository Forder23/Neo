using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NeoHealthSystemScript : MonoBehaviour
{
    private const int TOTAL_NUMBER_OF_LIFES = 5;

    [SerializeField]
    private Transform HeartsBoxParent;
    [SerializeField]
    private Image[] HeartObject;

    int NumberOfCurrentLife = TOTAL_NUMBER_OF_LIFES-1;
    void Start()
    {
        ////for loop for instantiating all hearts
        //for (int i = 0; i < TOTAL_NUMBER_OF_LIFES; i++)
        //{
        //    HeartObject[i].transform.position = HeartsBoxParent.position;            
        //    HeartObject[i].transform.position = new Vector3(HeartsBoxParent.transform.position.x + OffsetX * i, HeartsBoxParent.transform.position.y);
        //    Instantiate(HeartObject[i], HeartsBoxParent, true);
        //}
    }

    //function for taking one of the hearts
    public void TakeLife()
    {
        TakeOneLife();
    }
    private void TakeOneLife()
    {
        if (NumberOfCurrentLife > 0)
        {
            HeartObject[NumberOfCurrentLife].enabled = false;
            NumberOfCurrentLife--;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }   
    }
}

