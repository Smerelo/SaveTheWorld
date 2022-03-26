using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

public class PlayfabManager : MonoBehaviour
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
}
