using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

/// <summary>
/// Base class of all game "objects" (i.e crates, trees, items, etc)
/// </summary>
public class ObjectParent : NetworkBehaviour
{
    [SerializeField] [SyncVar] private float _health;
    
    public virtual float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;
        }
    }

    public virtual void Update()
    {
        if (Health <= 0) NetworkServer.Destroy(this.gameObject);
    }

    public virtual void TakeDamage(float damageTaken)
    {
        Health -= damageTaken;
    }
}
