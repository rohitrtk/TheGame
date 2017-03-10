using UnityEngine;
using UnityEngine.Networking;

public abstract class AbstractPlayer_Attack : NetworkBehaviour
{
    // Players auto attack range (relative to Unity units)
    protected bool _isAttacking;                        // Is the player attacking at this moment
    protected float _autoAttackRange;
    protected float _autoAttackCooldownTime;            // Mimimum amount of time between auto attacks

    /// <summary>
    /// Called to 'cast' an ability
    /// </summary>
    /// <param name="cast"></param>
    public abstract void Cast(string cast);

    /// <summary>
    /// Called to 'cast' an ability or auto attack that has a target
    /// </summary>
    /// <param name="cast"></param>
    /// <param name="target"></param>
    public abstract void Cast(string cast, GameObject target);

    /// <summary>
    /// Uses players normal attack ability
    /// </summary>
    /// <param name="target"></param>
    public abstract void AutoAttack(GameObject target);

    /// <summary>
    /// Uses players ability 1
    /// </summary>
    public abstract void Ability1();

    /// <summary>
    /// Uses players ability 2
    /// </summary>
    public abstract void Ability2();

    /// <summary>
    /// Uses players ability 3
    /// </summary>
    public abstract void Ability3();

    /// <summary>
    /// Uses players ability 4
    /// </summary>
    public abstract void Ability4();

    public virtual bool GetIsAttacking()
    {
        return _isAttacking;
    }
}