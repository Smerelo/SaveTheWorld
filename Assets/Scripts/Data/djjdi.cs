using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;
using TMPro;
using UnityEngine.UI;
public class PlayFabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    [SerializeField] private GameObject ipad;
    [SerializeField] private GameObject ipadLeaderBoardScreen;
    [SerializeField] private GameObject earthScreen;
    [SerializeField] private GameObject panelButton;


    public TextMeshProUGUI nameInput;

    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void Login()
    {

        if (nameInput.text.Length < 2)
            return;
        var request = new LoginWithCustomIDRequest
        {
            CustomId = nameInput.text,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSucess, OnError);
    }

    // public void RegisterButton()
    // {
    //     var request = new RegisterPlayFabUserRequest{
    //             Email = emailInput.text,
    //             Password = passwordInput.text,
    //             RequireBothUsernameAndEmail = false
    //     };
    //     PlayFabClientAPI.RegisterPlayFabUser(request,OnRegisterSuccess, OnError);


    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        // messageText
    }

    void OnSucess(LoginResult result)
    {
        Debug.Log("Account Succesfully created/SuccessfulLogin");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        SubmitNameButton();
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
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnleaderboardGet, OnError);
    }

    private void OnleaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString() + "/100";
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void LeaderboardDisplay(int score)
    {
        SendLeaderboard(score);
        ipad.GetComponent<Animator>().SetBool("Ipad", true);
        ipadLeaderBoardScreen.SetActive(true);
        ipad.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(WaitOneSec(3f));
    }
    IEnumerator WaitOneSec(float time)
    {
        yield return new WaitForSeconds(time);
        GetLeaderboard();
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name");
    }
}