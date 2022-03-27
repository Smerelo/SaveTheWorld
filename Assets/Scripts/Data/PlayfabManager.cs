using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    [SerializeField] private GameObject ipad;
    [SerializeField] private GameObject ipadLeaderBoardScreen;
    [SerializeField] private GameObject earthScreen;

    
    public int score;
    void Start()
    {
        Login();
    }
    void Login()
    {
        var request= new LoginWithCustomIDRequest{
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSucess, OnError);
    }
    void OnSucess(LoginResult result)
    {
            Debug.Log("Account Succesfully created/SuccessfulLogin");
    }

        void OnError(PlayFabError error)
    {
            Debug.Log("Error while login");
            Debug.Log(error.GenerateErrorReport());
}

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "Score",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnleaderboardUpdate, OnError);
    }

    private void OnleaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("leaderboard sent successfully");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest{
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10 
        };
        PlayFabClientAPI.GetLeaderboard(request, OnleaderboardGet, OnError);
    }

    private void OnleaderboardGet(GetLeaderboardResult result)
    {
        Debug.Log("yo");
        foreach(Transform item in rowsParent){
            Destroy(item.gameObject);
        }
            foreach(var item in result.Leaderboard)
            {
                GameObject newGo = Instantiate(rowPrefab,rowsParent);
                TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text = (item.Position + 1).ToString();
                texts[1].text = item.PlayFabId;
                texts[2].text = item.StatValue.ToString();
                Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
            }
    }

    public void LeaderboardDisplay(int score)
    {
        SendLeaderboard(score);
        ipad.GetComponent<Animator>().SetBool("Ipad", true);
        ipadLeaderBoardScreen.SetActive(true);
        GetLeaderboard();
        //   earthScreen.SetActive(false);
    }
}