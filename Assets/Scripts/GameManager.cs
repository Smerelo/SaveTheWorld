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
    [SerializeField] private int catastropheTreshold = 15;
    private int finalScore;
    [SerializeField] private CardUI card1, card2;
    private CardManager cardManager;
    private EarthState earthState;
    private PlayFabManager playFabManager;
    public float catastropheChance = 0f;
    private CardButton[] cards;
    private int roundsSinceTreshold = 0, catastropheMultiplier = 0;
    public int ecology = 25, happiness = 25, science = 25, economy = 25, turn = 0;
    private bool catastrophe;
    private bool catastropheHappened;
    private bool ecologyCatastrophe;
    private bool economyCatastrophe;
    private bool happinessCatastrophe;
    private int tweenId = 0;

    private bool GameEnded { get; set; }
    private bool TresholdReached { get; set; }



    void Start()
    {
        earthState = FindObjectOfType<EarthState>();
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        cards = cardManager.GetCards();
        UpdateStats();
        finalScore = 35;
    }

    void Update()
    {
        if (currentYear == endYear && GameEnded == false)
        {       
            EndGame();
        }       
    }

    private void EndGame()
    {
        playFabManager.LeaderboardDisplay(finalScore);        
        GameEnded = true;
    }

    public void MakeChoice(int choice)
    {
        if (catastrophe)
        {
            catastrophe = false;
            catastropheHappened = true;
        }
        if (!GameEnded)
        {
            turn++;

            currentYear++;
            yearText.text = currentYear.ToString();
            AddPoints(cards[choice].cardData);
            UpdateStats();
            if (turn % 3 == 0)
            {
                ShowStats();
            }
            if (!catastrophe)
            {
                cardManager.RemoveCard(cards[0].cardData, cards[1].cardData);
                cards = cardManager.GetCards();
            }
        }

    }


    private void ShowStats()
    {

        earthState.UpdateEarthState();
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
        if (!catastropheHappened)
        {
            CheckForCatastrophe();

        }
    }

    private void CheckForCatastrophe()
    {
      
        if (TresholdReached)
        {
            CompareTresholds();
            roundsSinceTreshold++;
            if (roundsSinceTreshold >= 1)
            {
                catastropheChance += 5f * catastropheMultiplier;
            }
            int rand = UnityEngine.Random.Range(0, 100);
            if (rand < catastropheChance)
            {
                catastrophe = true;
                Catastrophe();


            }
        }
        else
        {
            CheckTresholds();
        }
    }

    private void Catastrophe()
    {
        if (ecologyCatastrophe)
        {
             cards  = cardManager.GetEcoCards();
            Debug.Log("EcoCatastrophe");
        }
        else  if (economyCatastrophe)
        {
            cards = cardManager.GetEconCards();

            Debug.Log("EconCatastrophe");

        }
        else if (happinessCatastrophe)
        {
            cards = cardManager.GetHappyCards();

            Debug.Log("happCatastrophe");

        }
        ecologyCatastrophe = false;
        happinessCatastrophe = false;
        economyCatastrophe = false;
    }

    private void GetEcoCards()
    {
        throw new NotImplementedException();
    }

    private void CompareTresholds()
    {
        int i = 0;
        if (ecology < catastropheTreshold)
        {
            i++;
            ecologyCatastrophe = true;
        }
        else
        {
            ecologyCatastrophe = false;
        }

        if (economy < catastropheTreshold)
        {
            i++;
            economyCatastrophe = true;
        }
        else
        {
            economyCatastrophe = false;

        }

        if (happiness < catastropheTreshold)
        {
            happinessCatastrophe = true;

            i++;
        }
        else
        {
            happinessCatastrophe = false;

        }

        if (i > 0)
            TresholdReached = true;

        else
        {
            roundsSinceTreshold = 0;
            TresholdReached = false;
        }
    }

    private void CheckTresholds()
    {
        if (ecology < catastropheTreshold)
        {
            catastropheMultiplier++;
            ecologyCatastrophe = true;
        }
        else
        {
            ecologyCatastrophe = false;
        }

        if (economy < catastropheTreshold)
        {
            catastropheMultiplier++;
            economyCatastrophe = true;
        }
        else
        {
            economyCatastrophe = false;

        }

        if (happiness < catastropheTreshold)
        {
            happinessCatastrophe = true;

            catastropheMultiplier++;
        }
        else
        {
            happinessCatastrophe = false;

        }

        if (catastropheMultiplier > 0)
            TresholdReached = true;

        else
            TresholdReached = false;
    }
}
