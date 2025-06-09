using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/shopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<ShopItem> _shopItems;

    public IEnumerable<ShopItem> ShopItems => _shopItems;
}
