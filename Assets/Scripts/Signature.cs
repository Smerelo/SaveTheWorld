using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Signature : MonoBehaviour
{
    
    public int id;
    public GameManager gameManager;
    public Animator animator;
    private GameObject cardButtonL;
    private GameObject cardButtonR;

    private GameObject Card;
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cardButtonL = GameObject.Find("CardButtonL");
        cardButtonR = GameObject.Find("CardButtonR");
    }
    public void Sign()
    {
        animator.SetBool("PaperSigned", true);
        StartCoroutine(WaitOneSec(1.2f));
    }

    public void EnableButtons()
    {
        cardButtonL.GetComponent<Button>().enabled = false;
        cardButtonR.GetComponent<Button>().enabled = false;
    }
    IEnumerator WaitOneSec(float time)
    {
        AudioManager.AudioInstance.Play("Paper");
        yield return new WaitForSeconds(time);
        animator.SetBool("PaperSigned", false);
        cardButtonL.GetComponent<Button>().enabled = true;
        cardButtonR.GetComponent<Button>().enabled = true;
        gameManager.MakeChoice(id); 
    }
}
