using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Abstract class for enemies
/// </summary>
public abstract class AbstractEnemy : MonoBehaviour
{
    protected NavMeshAgent _navMeshAgent;

    [SerializeField] private float _hp;
    private float _moveSpeed;
    private float _moveAcceleration;
    private float _moveDeceleration;

    public float Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    protected float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }

        set
        {
            _moveSpeed = value;
        }
    }
    protected float MoveAcceleration
    {
        get
        {
            return _moveAcceleration;
        }

        set
        {
            _moveAcceleration = value;
        }
    }
    protected float MoveDeceleration
    {
        get
        {
            return _moveDeceleration;
        }

        set
        {
            _moveDeceleration = value;
        }
    }

    /// <summary>
    /// Responsible for checking if there's a player within the enemies check sphere
    /// </summary>
    protected abstract void Find();

    //protected float _autoAttackRange;
    //protected float _autoAttackCooldown;
    //protected bool _isMoving;
    //protected bool _isAttacking;
}
