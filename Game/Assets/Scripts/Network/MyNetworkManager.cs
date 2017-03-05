using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// My own network manager, extends from Unitities network
/// </summary>
public class MyNetworkManager : NetworkManager
{
    public new void StartHost()
    {
        SetPort();
        singleton.StartHost();

        print("Hosting on: " + singleton.networkAddress);
    }
	
    public void JoinGame()
    {
        SetIPAdress();
        SetPort();

        

        singleton.StartClient();

        print("Connected to: " + singleton.networkAddress);
    }

    private void SetPort()
    {
        singleton.networkPort = 7777;
    }

    private void SetIPAdress()
    {
        var ipAdress = GameObject.Find("InputIP").transform.FindChild("Text").GetComponent<Text>().text;
        singleton.networkAddress = ipAdress;
        print(ipAdress);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            StartCoroutine(LoadMenuButtons());
            return;
        }

        LoadLevelButtons();
    }

    private IEnumerator LoadMenuButtons()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("button_StartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_StartHost").GetComponent<Button>().onClick.AddListener(StartHost);

        GameObject.Find("button_JoinMatch").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_JoinMatch").GetComponent<Button>().onClick.AddListener(JoinGame);
    }

    private void LoadLevelButtons()
    {
        GameObject.Find("button_Disconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_Disconnect").GetComponent<Button>().onClick.AddListener(singleton.StopHost);
    }
}