using UnityEngine;

public class Seller : MonoBehaviour, IInteractable
{
    
    
    private Shop _shop;

    public void Initialize()
    {
        _shop = new Shop();
    }

    public void Interact()
    {
        Debug.Log("Sosal");
    }
}
