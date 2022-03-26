using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public Image    image;
    public string   title;
    public string   description;
    public int      ecology;
    public int      happiness;
    public int      science;
    public int      economy;
}