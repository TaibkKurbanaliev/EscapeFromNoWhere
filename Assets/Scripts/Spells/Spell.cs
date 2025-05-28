using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private Sprite m_Icon;
    [field: SerializeField] protected float Damage { get; private set; }
    //[field: SerializeField] protected AudioClip DestroySound { get; private set; }

    public abstract void ApplyDamage();
    public abstract void Cast(Vector3 target);
    public virtual void Initialize() { }
}
