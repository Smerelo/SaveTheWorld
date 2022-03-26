using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardDatabase cardDatabase;
    [SerializeField] private CardButton[] cardButtons;
    public List<Card> CardList;
    private List<Card>[][] Cards;

    private void Awake()
    {
        Cards = FillLists();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private List<Card>[][] FillLists()
    {
        List<Card>[][] temp = new List<Card>[4][];

        for (int i = 0; i < 4; i++)
        {
            temp[i] = new List<Card>[4];
            for (int j = 0; j < 4; j++)
            {
                temp[i][j] = new List<Card>();

            }
        }

        int e = 0;
        foreach (Card card in CardList)
        {
            e++;
            temp[(int)card.type][(int)card.tier].Add(card);
            Debug.Log($"type {(int)card.type} tier {(int)card.tier}  Cardnb {e}  list Count {temp[(int)card.type][(int)card.tier].Count}");
        }
        return temp;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CardButton[] GetCards()
    {
        int n = UnityEngine.Random.Range(0, CardList.Count);
        Card[] cardsData = new Card[2];
        cardsData[0] = CardList[n];
        if ((int)cardsData[0].tier == 3)
            cardsData[1] = GetNeutralCard();
        else
            cardsData[1] = GetSecondCard(cardsData[0]);
        FillCards(cardsData);
        return cardButtons;
    }

    private Card GetNeutralCard()
    {
        Card card = new Card();
        int n = 0;
        for (int i = 0; i < 20; i++)
        {
            n = UnityEngine.Random.Range(0, 4);
            if (Cards[n][3].Count != 0)
            {
                card = Cards[n][3][UnityEngine.Random.Range(0, Cards[n][3].Count)];
                break;
            }
        }

        return card;
    }

    private Card GetSecondCard(Card card)
    {
        int r = GetRandomNumber((int)card.type, (int)card.tier);
        int i = UnityEngine.Random.Range(0, Cards[r][(int)card.tier].Count);
        Card t = Cards[(int)card.type][(int)card.tier][i];
        return t;
    }

    private int GetRandomNumber( int i, int r)
    {
        int t = -1;
        for (int j = 0; j < 100; j++)
        {
            t = UnityEngine.Random.Range(0, 4);
            if (t != i  && Cards[t][r].Count != 0)
            {
                break;
            }
            Debug.Log($"t {t} i {i} r {r} count {Cards[t][r].Count}");
        }
        return t;
    }
   

    private void FillCards(Card[] cards)
    {
        for (int i = 0; i < cardButtons.Length; i++)
        {
            cardButtons[i].title.text = cards[i].title;
            cardButtons[i].description.text = cards[i].description;
            cardButtons[i].sprite = cards[i].sprite;
            cardButtons[i].cardData = cards[i];
        }
    }

    public void RemoveCard(Card card)
    {
        CardList.Remove(card);
    }
}
