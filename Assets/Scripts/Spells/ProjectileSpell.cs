using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ProjectileSpell : Spell
{
    [field:SerializeField] public float Speed {  get; private set; }

    protected Rigidbody Rb { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        Rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable) && other.TryGetComponent(out Enemy enemy))
        {
            damagable.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}
