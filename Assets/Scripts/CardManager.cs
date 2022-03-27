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
        i1 = n;
        if ((int)cardsData[0].type == 3)
            cardsData[1] = GetNeutralCard();
        else
            cardsData[1] = GetSecondCard(cardsData[0]);
        FillCards(cardsData);
        return cardButtons;
    }

    private Card GetNeutralCard()
    {
        Card card = null;
        int n = 0;
        for (int i = 0; i < 20; i++)
        {
            n = UnityEngine.Random.Range(0, 4);
            if (Cards[3][n].Count != 0)
            {
                i2 = n;
                card = Cards[3][n][UnityEngine.Random.Range(0, Cards[3][n].Count)];
                return card;
            }
        }

        return card;
    }

    private Card GetSecondCard(Card card)
    {
        int rand = GetRandomNumber((int)card.type, (int)card.tier);
        int cardIndex = UnityEngine.Random.Range(0, Cards[rand][(int)card.tier].Count);
        i2 = cardIndex;
        //Debug.Log($"rand {rand} tier {(int)card.tier} ");
        if (cardIndex >= Cards[rand][(int)card.tier].Count)
        {
            cardIndex = 0 ;
        }
        Card cardTemp = Cards[(int)card.type][(int)card.tier][cardIndex];
        return cardTemp;
    }

    private int GetRandomNumber( int type, int tier)
    {
        int t = -1;
        for (int j = 0; j < 100; j++)
        {
            t = UnityEngine.Random.Range(0, 4);
            if (t != type  && Cards[t][tier].Count != 0)
            {
                return t;
            }
            //Debug.Log($"t {t} i {type} r {tier} count {Cards[t][tier].Count}");
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

    public void RemoveCard(Card card1, Card card2)
    {
        Debug.Log($"type1 {(int)card1.type}  tier1 {(int)card1.tier}  i1 {i1}");
        Debug.Log($"type2 {(int)card2.type}  tier2 {(int)card2.tier} i2 {i2}  ");

        CardList.RemoveAt(i1);
        CardList.Remove(card2);

    }
}
