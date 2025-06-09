using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<Item> _shopItems;
    
    public IEnumerable<Item> ShopItems => _shopItems;
}
