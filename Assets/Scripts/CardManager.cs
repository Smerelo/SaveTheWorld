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

    // Start is called before the first frame update
    void Start()
    {
        Cards = FillLists();
        GetRandomNumber(0, 0);
    }

    private List<Card>[][] FillLists()
    {
        List<Card>[][] temp = new List<Card>[4][];

        for (int i = 0; i < 4; i++)
        {
            temp[i] = new List<Card>[3];
            for (int j = 0; j < 3; j++)
            {
                temp[i][j] = new List<Card>();
            }
        }

        foreach (Card card in CardList)
        {
            temp[(int)card.type][(int)card.tier].Add(card);
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
        n = UnityEngine.Random.Range(0, CardList.Count);
        cardsData[1] = GetSecondCard(cardsData[0]);
        
        CardList.Remove(cardsData[1]);

        FillCards(cardsData);
        return cardButtons;
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
        int t;
        int c = 0;
        Debug.Log(i + " " + r); 
        while ((t = UnityEngine.Random.Range(0, 4)) == i || Cards[t][r].Count == 0)
        {
            c++;
            if (c > 20)
            {
                break;
            }
            Debug.Log("NO CARDS");
            continue;
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
