using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [field : SerializeField] private List<ShopItem> _shopItems;
    
    public IEnumerable<ShopItem> ShopItems => _shopItems;
}
