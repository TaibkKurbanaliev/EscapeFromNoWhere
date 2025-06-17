using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : Panel
{
    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();

        foreach (var item in items)
        {
            ShopItemView spawnedItem = ItemViewFactory.Get(item, ItemsParent);

            spawnedItem.Click += OnItemViewClick;

            spawnedItem.UnSelect();
            spawnedItem.UnHighlight();

            ShopItems.Add(spawnedItem);
        }
    }

    protected override void OnItemViewClick(ShopItemView item)
    {
        base.OnItemViewClick(item);
        Highlight(item);
    }

    private void Highlight(ShopItemView itemView)
    {
        foreach (var item in ShopItems)
        {
            item.UnHighlight();
        }

        itemView.Highlight();
    }

    private void Clear()
    {
        foreach (var item in ShopItems)
        {
            item.Click -= OnItemViewClick;
            Destroy(item.gameObject);
        }

        ShopItems.Clear();
    }
}
