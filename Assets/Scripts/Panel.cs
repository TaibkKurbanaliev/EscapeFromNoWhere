using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    public event Action<ShopItemView> ItemViewClicked;

    [field: SerializeField] protected Transform ItemsParent { get; private set; }
    [field: SerializeField] protected ShopItemViewFactory ItemViewFactory { get; private set; }

    protected List<ShopItemView> ShopItems = new();

    public virtual void Show()
    {

    }

    protected virtual void OnItemViewClick(ShopItemView item)
    {
        ItemViewClicked?.Invoke(item);
    }
}
