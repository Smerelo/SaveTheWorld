using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signature : MonoBehaviour
{
    
    public GameObject animation;

    public void PlayAnimation()
    {
        animation.SetActive(true);
    }
}
