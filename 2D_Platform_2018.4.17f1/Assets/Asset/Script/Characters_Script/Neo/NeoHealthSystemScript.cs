﻿using System.Collections;
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
    private Image[] HeartObject = new Image[NumberOfCurrentLife];

    private static int NumberOfCurrentLife = TOTAL_NUMBER_OF_LIFES;

    [SerializeField]
    private GameObject Heart;

    private bool LostLife; //variable used for disappearing platform in second lvl
    private void IsLost(bool Lost) { LostLife = Lost; }
    public void SetIsLifeLost(bool _LostLife)
    {
        IsLost(_LostLife);
    }
    public bool GetIsLostLife() { return LostLife; }

    public static int GetTotalLifes() { return TOTAL_NUMBER_OF_LIFES; }
    public static int GetNumberOfCurrentLifes() { return NumberOfCurrentLife; }
    public static void SetNumberOfCurrentLifes(int Lifes) { NumberOfCurrentLife = Lifes; }

    void Start()
    {
        ////for loop for instantiating all hearts
        //for (int i = 0; i < TOTAL_NUMBER_OF_LIFES; i++)
        //{
        //    HeartObject[i].transform.position = HeartsBoxParent.position;            
        //    HeartObject[i].transform.position = new Vector3(HeartsBoxParent.transform.position.x + OffsetX * i, HeartsBoxParent.transform.position.y);
        //    Instantiate(HeartObject[i], HeartsBoxParent, true);
        //}
        for (int i = 0; i < HeartObject.Length; i++)
        {
            HeartObject[i].enabled = false;
        }
        ShowHearts();
        Debug.Log($"LIFES: {NumberOfCurrentLife}");
    }

    void ShowHearts()
    {
        for (int i = 0; i < NumberOfCurrentLife; i++)
        {
            HeartObject[i].enabled = true;
        }
    }
    //function for taking one of the hearts
    public void TakeLife()
    {
        TakeOneLife();
    }
    private void TakeOneLife()
    {
        if (NumberOfCurrentLife > 1)
        {
            --NumberOfCurrentLife;
            HeartObject[NumberOfCurrentLife].enabled = false;
            SetIsLifeLost(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            NumberOfCurrentLife = TOTAL_NUMBER_OF_LIFES;
        }

    }

    private void AddOneLife()
    {
        if (NumberOfCurrentLife == 5)
        {
            Heart.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (NumberOfCurrentLife < TOTAL_NUMBER_OF_LIFES)
        {           
            NumberOfCurrentLife++;
            HeartObject[NumberOfCurrentLife-1].enabled = true;
        }
    }

    public void AddLife()
    {
        AddOneLife();
    }
}

