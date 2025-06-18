using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] ItemSO _itemStartConfiguration;
    public int Cost { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Sprite Icon { get; private set; }

    public void Initialize()
    {
        Cost = _itemStartConfiguration.Cost;
        Name = _itemStartConfiguration.Name;
        Description = _itemStartConfiguration.Description;
        Icon = _itemStartConfiguration.Icon;
    }

    public virtual void Destroy()
    {

    }

    public virtual void Drop()
    {

    }

    public virtual void Pick()
    {

    }
}
