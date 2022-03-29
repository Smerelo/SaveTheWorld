using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{

    private GameManager gameManager;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
        
        int score = (int)gameManager.finalScore;
        text.text = score.ToString() + "/100";
    }
}
