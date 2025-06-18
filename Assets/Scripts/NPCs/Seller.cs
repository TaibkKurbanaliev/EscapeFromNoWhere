using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour, IInteractable
{
    [SerializeField] private Content _shopContent;

    private Shop _shop;

    public void Initialize()
    {
        _shop = FindFirstObjectByType<Shop>(FindObjectsInactive.Include);
    }

    public void Interact()
    {
        _shop.gameObject.SetActive(true);
        _shop.Show(_shopContent);
    }
}
