using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Drawing;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentYear = 0, endYear = 20;
    [SerializeField] private TextMeshPro yearText;

    private CardManager cardManager;
    private CardButton[] cards;
    private int ecology = 50, happiness = 50, science = 50, economy = 50;
    private bool GameEnded { get; set; }
    

    void Start()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        cards = cardManager.GetCards();
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
        GameEnded = true;
    }

    public void MakeChoice(int choice)
    {
        if (!GameEnded)
        {
            currentYear++;
            yearText.text = currentYear.ToString();
            AddPoints(cards[choice].cardData);
            cards = cardManager.GetCards();
        }

    }

    private void AddPoints(Card card)
    {
        ecology += card.ecology;
        happiness += card.happiness;
        science += card.science;
        economy += card.economy;
    }
}
