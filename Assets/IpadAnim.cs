using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;


public class IpadAnim : MonoBehaviour
{
    public Animator animator;
    public Button[] button;

    public void OnMouseDown()
    {
        if (animator.GetBool("Ipad") == true)
        {
            animator.SetBool("Ipad", false);
        }
        else
        {
            animator.SetBool("Ipad", true);
        }
    }

    public void SetInteractableTrue()
    {
        button[0].interactable = true;
        button[1].interactable = true;
    }
    public void SetInteractableFalse()
    {
        button[0].interactable = false;
        button[1].interactable = false;
    }
}
