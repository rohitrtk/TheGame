using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player_Health : ObjectParent
{
    [SyncVar] private bool dead;

    protected bool Dead
    {
        get
        {
            return dead;
        }

        set
        {
            dead = value;
        }
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public void Start ()
    {
        Health = 100;
        Dead = false;
	}

    public override void Update()
    {
        if (Health <= 0)
        {
            Dead = true;
            NetworkServer.Destroy(this.gameObject);
        }
    }

    public override void TakeDamage(float damageTaken)
    {
        base.TakeDamage(damageTaken);
        print(damageTaken);
    }
}