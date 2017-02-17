using UnityEngine;
using UnityEngine.Networking;

public abstract class AbstractPlayer_Attack : NetworkBehaviour
{
    protected float _autoAttackRange;
    public abstract void AutoAttack(GameObject target);
    public abstract void Ability1();
    public abstract void Ability2();
    public abstract void Ability3();
    public abstract void Ability4(); 
}
