using UnityEngine;
using UnityEngine.Networking;

public class Destruct : NetworkBehaviour
{
    [Command]
    public void CmdCanDestruct()
    {
        NetworkServer.Destroy(gameObject);
    }
}