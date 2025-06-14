using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public event Action<ShopItemView> ItemViewClicked;

    [SerializeField] private Transform _itemsParent;
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;

    private List<ShopItemView> _shopItems = new();

    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();

        foreach (var item in items)
        {
            ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _itemsParent);

            spawnedItem.Click += OnItemViewClick;

            spawnedItem.UnSelect();
            spawnedItem.UnHighlight();

            _shopItems.Add(spawnedItem);
        }
    }

    private void OnItemViewClick(ShopItemView item)
    {
        Highlight(item);
        ItemViewClicked?.Invoke(item);
    }

    private void Highlight(ShopItemView itemView)
    {
        foreach (var item in _shopItems)
        {
            item.UnHighlight();
        }

        itemView.Highlight();
    }

    private void Clear()
    {
        foreach (var item in _shopItems)
        {
            item.Click -= OnItemViewClick;
            Destroy(item.gameObject);
        }

        _shopItems.Clear();
    }
}
