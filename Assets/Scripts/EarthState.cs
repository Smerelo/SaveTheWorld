using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthState : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] ecologySprite;
    public GameObject[] economySprite;
    public GameObject[] scienceSprite;
    public GameObject[] happinessSprite;

    public Sprite _sprite;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //ChangeEarthState();
    }

    public void EconomyStates()
    {
        if (gameManager.economy >= 50)
            economySprite[1].SetActive(true);
        else if (gameManager.economy >= 25)
            economySprite[2].SetActive(true);
        else
            economySprite[3].SetActive(true);
    }

    public void EcologyStates()
    {
        if (gameManager.ecology >= 50)
            ecologySprite[1].SetActive(true);
        else if (gameManager.ecology >= 25)
            ecologySprite[2].SetActive(true);
        else
            ecologySprite[3].SetActive(true);

    }

    public void ScienceStates()
    {
        if (gameManager.science >= 50)
            scienceSprite[1].SetActive(true);
        else if (gameManager.science >= 25)
            scienceSprite[2].SetActive(true);

        else
            scienceSprite[3].SetActive(true);

    }

    public void HappinessStates()
    {
        if (gameManager.happiness >= 50)
            happinessSprite[1].SetActive(true);

        else if (gameManager.happiness >= 25)
            happinessSprite[2].SetActive(true);

        else
            happinessSprite[3].SetActive(true);

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
}