using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

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

        if (!NetworkServer.active) return;

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
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            LoadMenuButtons();
            return;
        }

        LoadLevelButtons();
    }

    private void LoadMenuButtons()
    {
        //GameObject.Find("button_StartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_StartHost").GetComponent<Button>().onClick.AddListener(StartHost);

        //GameObject.Find("button_JoinMatch").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_JoinMatch").GetComponent<Button>().onClick.AddListener(JoinGame);
    }

    private void LoadLevelButtons()
    {
        GameObject.Find("button_Disconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_Disconnect").GetComponent<Button>().onClick.AddListener(singleton.StopHost);
    }
}