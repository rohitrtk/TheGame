using UnityEngine;
using UnityEngine.Networking;

public class Destruct : NetworkBehaviour
{
    public void CanDestruct()
    {
        NetworkServer.Destroy(gameObject);
    }
}