using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

/// <summary>
/// Abstract class for player attacks
/// </summary>
public abstract class AbstractPlayer_Attack : NetworkBehaviour
{
    // Players auto attack range (relative to Unity units)
    protected bool _isAttacking;                        // Is the player attacking at this moment
    private float autoAttackRange;                      // The range for auto attacks
    protected float _autoAttackCooldownTime;            // Mimimum amount of time between auto attacks

    public float AutoAttackRange
    {
        get
        {
            return autoAttackRange;
        }

        set
        {
            autoAttackRange = value;
        }
    }

    /// <summary>
    /// Called to 'cast' an ability
    /// </summary>
    /// <param name="cast"></param>
    public abstract bool Cast(string cast);

    /// <summary>
    /// Called to 'cast' an ability or auto attack that has a target
    /// </summary>
    /// <param name="cast"></param>
    /// <param name="target"></param>
    public abstract bool Cast(string cast, GameObject target);

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

    /// <summary>
    /// Casts a ray to check for target
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public virtual IEnumerator DeployMeleeRay(GameObject target)
    {
        // Wait for the animation to look as though it's attacking
        yield return new WaitForSeconds(0.5f * GetComponent<Animator>().speed);

        Vector3 forward = transform.TransformDirection(Vector3.forward);                    // The forward vector relative to the gameobject as opposed to the world
        Vector3 rayVector = transform.position + new Vector3(0f, 2f, 0f);                   // The position to fire from relative to the player

        //Debug.DrawRay(transform.position + new Vector3(0, 2f, 0), forward*_autoAttackRange, Color.green, 10);

        Ray direction = new Ray(rayVector, forward);                                        // Direction to fire the ray from
        RaycastHit rayInfo;                                                                 // Information about the object hit with the ray cast

        if(Physics.Raycast(direction, out rayInfo, AutoAttackRange))
        {
            print(rayInfo.collider.gameObject + " | " + target.gameObject);
            
            string targetTag = target.tag;

            if (targetTag == "Destructable" && target == rayInfo.collider.gameObject)
            {
                var v = GetComponent<Player_Movement>();
                if (v.GetIsMoving())
                {
                    v.SetIsMoving(false);
                }

                _isAttacking = true;
                if (!Network.isServer) CmdClientA(target);
                else RpcServerA(target);
            }
        }
    }

    [ClientRpc]
    protected void RpcServerA(GameObject rayObject)
    {
        NetworkServer.Destroy(rayObject);
    }

    [Command]
    protected void CmdClientA(GameObject rayObject)
    {
        RpcServerA(rayObject);
    }
}