using UnityEngine;

public abstract class NPC : MonoBehaviour, IDamagable
{
    protected bool IsAlive { get { return Health < 0; } }

    [Header("NPC Stats")]
    [field: SerializeField] public float Health { get; protected set; }
    [field: SerializeField] public float AttackRange { get; protected set; }

    public virtual void TakeDamage(float damage)
    {
        if (Health < 0)
            return;

        Health -= damage;
    }
}
