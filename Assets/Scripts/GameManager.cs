using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentYear = 0, endYear = 20;
    [SerializeField] private TextMeshPro yearText;
    private int ecology = 50, happiness = 50, science = 50, economy = 50;
    private bool GameEnded { get; set; }
    

    void Start()
    {
        
    }

    void Update()
    {
        if (currentYear == endYear)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game end");
        GameEnded = true;
    }

    public void MakeChoice()
    {
        if (!GameEnded)
        {
            currentYear++;
            yearText.text = currentYear.ToString();
        }

    }
}
