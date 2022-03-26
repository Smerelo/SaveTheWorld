using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class PlayFabManager : MonoBehaviour
{
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

    public void SendLeaderboard(int score, string statisticName)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = statisticName,
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
            StatisticName = "HappinessScore",
            StartPosition = 0,
            MaxResultsCount = 10 
        };
        PlayFabClientAPI.GetLeaderboard(request, OnleaderboardGet, OnError);
    }

    private void OnleaderboardGet(GetLeaderboardResult result)
    {
            foreach(var item in result.Leaderboard)
            {
                Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
            }
    }
}