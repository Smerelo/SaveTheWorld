using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Type { HIGH, LOW, MEDIUM, NEUTRAL };
public enum StatType { ECONOMY, HAPPINESS, ECOLOGY, SCIENCE };

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public Sprite sprite;
    public string title;
    public string description;
    public int economy;
    public int happiness;
    public int ecology;
    public int science;
    public Type tier;
    public StatType type;

}

public GameObject animation;

    public void PlayAnimation()
    {
        animation.SetActive(true);
    }
}
