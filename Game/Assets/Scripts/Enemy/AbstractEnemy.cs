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
    protected const float _STOPPINGDISTANCE = 1f;
    protected float _moveSpeed;
    protected float _moveAcceleration;
    protected float _moveDeceleration;
    protected float _autoAttackRange;
    protected float _autoAttackCooldown;
    protected bool _isMoving;
    protected bool _isAttacking;
}
