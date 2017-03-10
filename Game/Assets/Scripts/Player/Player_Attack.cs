using System;
using UnityEngine;

public class Player_Attack : AbstractPlayer_Attack
{
    /// <summary>
    /// Called on gameobject created
    /// </summary>
    public void Start()
    {
        if (!isLocalPlayer) return;

        _autoAttackRange = 10f;
        _autoAttackCooldownTime = 0.5f;
    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    public void Update()
    {
        // If player is attacking...
        if (_isAttacking)
        {
            // If the attack cooldown is still going down...
            if(_autoAttackCooldownTime <= 0)
            {
                _autoAttackCooldownTime = 0.5f;
                _isAttacking = false;
            }
            else _autoAttackCooldownTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Called to 'cast' an ability  
    /// </summary>
    /// <param name="cast"></param>
    public override void Cast(string cast)
    {
        if (!isLocalPlayer) return;

        if (cast.Equals("ABILITY1")) Ability1();
        else if (cast.Equals("ABILITY2")) Ability2();
        else if (cast.Equals("ABILITY3")) Ability3();
        else if (cast.Equals("ABILITY4")) Ability4();
    }

    /// <summary>
    /// Called to 'cast' an ability or auto attack that has a target
    /// </summary>
    /// <param name="cast"></param>
    /// <param name="target"></param>
    public override void Cast(string cast, GameObject target)
    {
        if (!isLocalPlayer) return;

        if (cast.Equals("AUTO")) AutoAttack(target);
    }

    /// <summary>
    /// Uses players normal attack ability
    /// </summary>
    /// <param name="target"></param>
    public override void AutoAttack(GameObject target)
    {
        if (!isLocalPlayer || _isAttacking) return;

        _isAttacking = true;

        string targetTag = target.tag;
        
        if(targetTag == "Destructable")
        {
            Destruct d = target.GetComponent<Destruct>();
            d.CanDestruct();
        }
    }

    /// <summary>
    /// Uses players ability 1
    /// </summary>
    public override void Ability1()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Uses players ability 2
    /// </summary>
    public override void Ability2()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Uses players ability 3
    /// </summary>
    public override void Ability3()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Uses players ability 4
    /// </summary>
    public override void Ability4()
    {
        //if (!isLocalPlayer) return;
        throw new NotImplementedException();
    }
}