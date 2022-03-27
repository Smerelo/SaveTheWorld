using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signature : MonoBehaviour
{
    
    public int id;
    public GameManager gameManager;
    public Animator animator;
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Sign()
    {
        animator.SetBool("PaperSigned", true);

        StartCoroutine(WaitOneSec(1));
    }

    IEnumerator WaitOneSec(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("PaperSigned", false);
        gameManager.MakeChoice(id);
    }
}
