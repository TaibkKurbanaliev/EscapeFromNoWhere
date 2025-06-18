using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    public event Action<ItemView> ItemViewClicked;

    [field: SerializeField] protected Transform ItemsParent { get; private set; }
    [field: SerializeField] protected ItemFactory ItemViewFactory { get; private set; }

    protected List<ItemView> Items = new();

    public virtual void Show(IEnumerable<Item> items)
    {
        Clear();

        foreach (var item in items)
        {
            ItemView spawnedItem = ItemViewFactory.Get(item, ItemsParent);
            spawnedItem.Click += OnItemViewClick;

            spawnedItem.UnSelect();
            spawnedItem.UnHighlight();

            Items.Add(spawnedItem);
        }
    }

    protected virtual void OnItemViewClick(ItemView item)
    {
        ItemViewClicked?.Invoke(item);
    }

    private void Clear()
    {
        foreach (var item in Items)
        {
            item.Click -= OnItemViewClick;
            Destroy(item.gameObject);
        }

        Items.Clear();
    }
}
