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

    public  void SetStates(int state, GameObject[] sprites)
    {
        if (state >= 50)
        {
            sprites[0].SetActive(true);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
        }
        else if (state >= 25)
        {
            sprites[1].SetActive(true);
            sprites[0].SetActive(false);
            sprites[2].SetActive(false);
        }
        else
        {
            sprites[2].SetActive(true);
            sprites[1].SetActive(false);
            sprites[0].SetActive(false);
        }
    }

    public void UpdateEarthState()
    {
        //************   economy   ************//
        //SetStates(gameManager.economy,economySprite) ;
        //************   ecology   ************//
        SetStates(gameManager.ecology, ecologySprite);
        //************  science  ************//
        SetStates(gameManager.science, scienceSprite);
        //************   happiness   ************//
        //SetStates(gameManager.happiness, happinessSprite);
    }
}