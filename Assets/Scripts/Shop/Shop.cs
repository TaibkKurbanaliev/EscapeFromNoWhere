using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour 
{
    [SerializeField] private ShopPanel _shopPanel;

    public void Show(ShopContent content) => _shopPanel.Show(content.ShopItems.Cast<ShopItem>());
}
