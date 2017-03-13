using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

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
    public abstract void Cast(string cast,  NavMeshAgent navMesh);

    /// <summary>
    /// Called to 'cast' an ability or auto attack that has a target
    /// </summary>
    /// <param name="cast"></param>
    /// <param name="target"></param>
    public abstract int Cast(string cast, GameObject target, NavMeshAgent navMesh);

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

    /// <summary>
    /// Returns true if the player is attacking
    /// </summary>
    /// <returns></returns>
    public virtual bool GetIsAttacking()
    {
        return _isAttacking;
    }

    public virtual IEnumerator DeployMeleeRay(GameObject target)
    {// FIX ATTACK SCRIPT; IT'S NOT RUNNING?!?!?!?!
        yield return new WaitForSeconds(0.5f * GetComponent<Animator>().speed);

        RaycastHit rayInfo;
        Ray direction = new Ray(transform.position, Vector3.forward);

        if(Physics.Raycast(direction, out rayInfo, _autoAttackRange))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 2, 0), Vector3.forward, Color.green, 10f);
            string targetTag = target.tag;

            if (targetTag == "Destructable")
            {
                Destruct d = target.GetComponent<Destruct>();
                d.CanDestruct();
            }
        }
    }
}