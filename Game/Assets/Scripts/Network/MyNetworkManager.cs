using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
     public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }
	
    public void JoinGame()
    {
        SetIPAdress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    private void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    private void SetIPAdress()
    {
        var ipAdress = GameObject.Find("InputIP").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAdress;
    }
}