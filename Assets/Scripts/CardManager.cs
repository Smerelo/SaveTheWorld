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
    public List<Card> CardListTwo;
    public List<Card> CardListThree;
    public List<Card> CardListCatastrophe;
    private List<Card>[][] Cards;
    private int i1 = 0, i2 = 0;
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
            //Debug.Log($"type {(int)card.type} tier {(int)card.tier}  Cardnb {e}  list Count {temp[(int)card.type][(int)card.tier].Count}");
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
        if ((int)cardsData[0].tier == 2)
        {
            if (!CheckMediumNb())
            {
                Debug.Log("1 " + Cards[(int)cardsData[0].type][(int)cardsData[0].tier].Remove(cardsData[0]));
                Debug.Log("3 " + CardList.Remove(cardsData[0]));
                 n = UnityEngine.Random.Range(0, CardList.Count);
                cardsData[0] = CardList[n];
            }
        }
        if ((int)cardsData[0].type == 3)
            cardsData[1] = GetNeutralCard(cardsData[0]);
        else
            cardsData[1] = GetSecondCard(cardsData[0]);
        FillCards(cardsData);
        return cardButtons;
    }

    private bool CheckMediumNb()
    {

        int i = 0;
        foreach (Card card in CardList)
        {
            if ((int)card.tier == 2 )
            {
                i++;
                if (i > 1)
                {
                    return true;
                }
            }
        }
        Debug.Log("LastMedium");
        return false;
        
    }

    private Card GetNeutralCard(Card cardData)
    {
        Debug.Log("here");

        Card card = null;
        int n = 0;
        for (int i = 0; i < 20; i++)
        {
            n = UnityEngine.Random.Range(0, 4);
            if (Cards[3][n].Count != 0)
            {
                i2 = n;
                card = Cards[3][n][UnityEngine.Random.Range(0, Cards[3][n].Count)];
                if (cardData.title == card.title)
                {
                    Debug.Log("loop");
                    continue;
                }
                return card;
            }
        }
        Debug.LogError("CACA2");

        return card;
    }

    private Card GetSecondCard(Card card)
    {
        Debug.Log("here2");
        int rand = GetRandomNumber((int)card.type, (int)card.tier, 4);
        Debug.Log((int)card.type + " type");
        Debug.Log(rand + " rand");
        int cardIndex = UnityEngine.Random.Range(0, Cards[rand][(int)card.tier].Count);
        i2 = cardIndex;
        //Debug.Log($"rand {rand} tier {(int)card.tier} ");
        if (cardIndex >= Cards[rand][(int)card.tier].Count)
        {
            cardIndex = 0;
        }
        Card cardTemp = Cards[rand][(int)card.tier][cardIndex];
        return cardTemp;
    }

    internal CardButton[] GetEconCards()
    {

        Card[] cardsData = new Card[2];
        cardsData[0] = CardListCatastrophe[0];
        cardsData[1] = CardListCatastrophe[1];
        FillCards(cardsData);
        return cardButtons;
    }

    internal CardButton[] GetHappyCards()
    {
        Card[] cardsData = new Card[2];
        cardsData[0] = CardListCatastrophe[4];
        cardsData[1] = CardListCatastrophe[5];
        FillCards(cardsData);
        return cardButtons;
    }

    internal CardButton[] GetEcoCards()
    {
        Card[] cardsData = new Card[2];
        cardsData[0] = CardListCatastrophe[2];
        cardsData[1] = CardListCatastrophe[3];
        FillCards(cardsData);
        return cardButtons;
    }

    private int GetRandomNumber( int type, int tier ,int max)
    {
        int t = -1;
        for (int j = 0; j < 100; j++)
        {
            t = UnityEngine.Random.Range(0, max);
            if (t != type  && Cards[t][tier].Count != 0)
            {
                return t;
            }
            //Debug.Log($"t {t} i {type} r {tier} count {Cards[t][tier].Count}");
        }
        t = type;
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

    public void RemoveCard(Card card1, Card card2)
    {
        Debug.Log( "1 " + Cards[(int)card1.type][(int) card1.tier].Remove(card1));
        Debug.Log("2 " + Cards[(int)card2.type][(int) card2.tier].Remove(card2));
        Debug.Log("3 " + CardList.Remove(card1));
        Debug.Log("4 " + CardList.Remove(card2));
        FillLists();
    }
}
