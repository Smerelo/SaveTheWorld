using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    int tweenId = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void MoveAway2()
    {
        tweenId = LeanTween.moveX(gameObject, transform.position.x - 10f, 2f).id;
    }

    internal void MoveAway1()
    {
        throw new NotImplementedException();
    }
}
