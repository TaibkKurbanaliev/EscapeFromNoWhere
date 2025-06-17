using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopContent _shopContent;

    private Shop _shop;

    public void Initialize()
    {
        _shop = FindFirstObjectByType<Shop>(FindObjectsInactive.Include);
    }

    public void Interact()
    {
        Debug.Log("Sosal");
        _shop.gameObject.SetActive(true);
        _shop.Show(_shopContent);
    }
}
