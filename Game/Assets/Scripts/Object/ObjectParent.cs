using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

/// <summary>
/// Base class of all game "objects" (i.e crates, trees, items, etc)
/// </summary>
public class ObjectParent : NetworkBehaviour
{
    [SyncVar]
    private float health;
    //asd
    public virtual float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    //[ServerCallback]
    public virtual void Update()
    {
        if (Health <= 0) NetworkServer.Destroy(this.gameObject);
    }

    public virtual void TakeDamage(float damageTaken)
    {
        Health -= damageTaken;
    }
}
