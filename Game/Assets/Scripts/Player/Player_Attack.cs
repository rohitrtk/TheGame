using System;
using UnityEngine;

public class Player_Attack : AbstractPlayer_Attack
{
    public Player_Attack()
    {
        _autoAttackRange = 10f;
    }

    public override void AutoAttack(GameObject target)
    {
        //if (!isLocalPlayer) return;
        string targetTag = target.tag;
        
        if(targetTag == "Destructable")
        {
            Destruct d = target.GetComponent<Destruct>();
            d.CanDestruct();
        }
    }

    public override void Ability1()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }

    public override void Ability2()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }

    public override void Ability3()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }

    public override void Ability4()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }
}
