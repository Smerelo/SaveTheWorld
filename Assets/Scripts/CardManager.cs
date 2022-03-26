using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardDatabase cardDatabase;
    public List<Card> cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = cardDatabase.cards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card GetFirstCard()
    {
        int n = UnityEngine.Random.Range(0, cards.Count);
        Card card = cards[n];
        return card;
    }
}
