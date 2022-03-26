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

    // Start is called before the first frame update
    void Start()
    {
        
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
        cardsData[1] = CardList[n];

        CardList.Remove(cardsData[1]);

        FillCards(cardsData);
        return cardButtons;
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
