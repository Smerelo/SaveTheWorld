using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    public void DisplayText()
    {

        displayText.gameObject.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
