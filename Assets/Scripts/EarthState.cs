using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthState : MonoBehaviour
{
    public GameManager gameManager;

    public Sprite[] ecologySprite = new Sprite[3];
    public Sprite[] economySprite = new Sprite[3];
    public Sprite[] scienceSprite = new Sprite[3];
    public Sprite[] happinessSprite = new Sprite[3];

    public Sprite _sprite;
    
    void start()
    {
        ChangeEarthState();
    }

    public void EconomyStates()
    {
        if (gameManager.ecology >= 50)
            DisplaySprite(ecologySprite[1]);
        else if (gameManager.ecology >= 25)
            DisplaySprite(ecologySprite[2]);
        else
            DisplaySprite(ecologySprite[3]);
    }

    public void EcologyStates()
    {
        if (gameManager.ecology >= 50)
            DisplaySprite(ecologySprite[1]);
        else if (gameManager.ecology >= 25)
            DisplaySprite(ecologySprite[2]);
        else
            DisplaySprite(ecologySprite[3]);
    }

    public void ScienceStates()
    {
        if (gameManager.science >= 50)
            DisplaySprite(scienceSprite[1]);
        else if (gameManager.science >= 25)
            DisplaySprite(scienceSprite[2]);
        else
            DisplaySprite(scienceSprite[3]);
    }

    public void HappinessStates()
    {
        if (gameManager.happiness >= 50)
            DisplaySprite(happinessSprite[1]);
        else if (gameManager.happiness >= 25)
            DisplaySprite(happinessSprite[2]);
        else
            DisplaySprite(happinessSprite[3]);
    }

    public void ChangeEarthState()
    {
        //************   economy   ************//
        EconomyStates();
        //************   ecology   ************//
        EcologyStates();
        //************  science  ************//
        ScienceStates();
        //************   happiness   ************//
        HappinessStates();
    }

    void DisplaySprite(Sprite sprite)
    {
        _sprite = sprite; 
    }
}
        