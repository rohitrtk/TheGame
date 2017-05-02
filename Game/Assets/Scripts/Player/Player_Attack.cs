using System;
using UnityEngine;

/// <summary>
/// This class handles the players attacks; extends from abstract player attack
/// </summary>
public class Player_Attack : AbstractPlayer_Attack
{
    /// <summary>
    /// Called on gameobject created
    /// </summary>
    public void Start()
    {
        if (!isLocalPlayer) return;

        _autoAttackRange = 5.5f;
        _autoAttackCooldownTime = 0.5f;
    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    public void Update()
    {
        if (!isLocalPlayer || !_isAttacking) return;

        // ATTACK STUFF HERE

        // If the attack cooldown is still going on...
        if (_autoAttackCooldownTime <= 0)
        {
            _autoAttackCooldownTime = 0.5f;
            _isAttacking = false;
        }
        else _autoAttackCooldownTime -= Time.deltaTime;
    }

    /// <summary>
    /// Called to 'cast' an ability  
    /// </summary>
    /// <param name="cast"></param>
    public override bool Cast(string cast)
    {
        if (!isLocalPlayer) return false;

        if (cast.Equals("ABILITY1")) Ability1();
        else if (cast.Equals("ABILITY2")) Ability2();
        else if (cast.Equals("ABILITY3")) Ability3();
        else if (cast.Equals("ABILITY4")) Ability4();

        return true;
    }

    /// <summary>
    /// Called to 'cast' an ability or auto attack that has a target
    /// </summary>
    /// <param name="cast"></param>
    /// <param name="target"></param>
    public override bool Cast(string cast, GameObject target)
    {
        if (!isLocalPlayer) return false;

        
        var distance = Vector3.Distance(transform.position, target.transform.position);
        
        // Auto attack
        if (cast.Equals("AUTO") && distance < _autoAttackRange) AutoAttack(target);

        return true;
    }

    /// <summary>
    /// Uses players normal attack ability
    /// </summary>
    /// <param name="target"></param>
    public override void AutoAttack(GameObject target)
    {
        if (!isLocalPlayer || _isAttacking) return;
        
        _isAttacking = true;

        StartCoroutine(DeployMeleeRay(target));
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