using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
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
