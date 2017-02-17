using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public void CanDestruct()
    {
        Destroy(gameObject);
    }
}