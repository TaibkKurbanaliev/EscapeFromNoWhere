using UnityEngine;

public class Fireball : ProjectileSpell
{
    public override void ApplyDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void Cast(Vector3 target)
    {
        Rb.AddForce(target.normalized * Speed, ForceMode.Impulse);
    }

    public override void Initialize()
    {
        base.Initialize();
    }
}
