using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Drawing;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentYear = 0, endYear = 100;
    [SerializeField] private TextMeshPro yearText;
    [SerializeField] private TextMeshPro[] stats;

    private CardManager cardManager;

    private PlayFabManager playFabManager;
    private CardButton[] cards;
    private int ecology = 25, happiness = 25, science = 25, economy = 25, turn = 0;
    private bool GameEnded { get; set; }
    

    void Start()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        cards = cardManager.GetCards();
        UpdateStats();
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
        //playFabManager.SendLeaderboard(happiness, "Happiness");        
        GameEnded = true;
    }

    public void MakeChoice(int choice)
    {
        if (!GameEnded)
        {
            turn++;
            if (turn % 5 == 0)
            {
                ShowStats();
            }
            currentYear++;
            yearText.text = currentYear.ToString();
            AddPoints(cards[choice].cardData);
            UpdateStats();
            cards = cardManager.GetCards();
        }

    }

    private void ShowStats()
    {
        
    }

    private void UpdateStats()
    {
        stats[0].text = "Eco " +  ecology.ToString();
        stats[1].text = "Happ " + happiness.ToString();
        stats[2].text = "sci " + science.ToString();
        stats[3].text = "econ " + economy.ToString();
    }

    private void AddPoints(Card card)
    {
        ecology =  Mathf.Clamp( ecology + card.ecology, 0, 100);
        happiness = Mathf.Clamp(happiness + card.happiness, 0, 100);
        science = Mathf.Clamp(science + card.science, 0, 100);
        economy = Mathf.Clamp(economy + card.economy, 0, 100);
        
    }
}
