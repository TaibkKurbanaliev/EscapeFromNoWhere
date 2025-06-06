using UnityEngine;

public class Seller : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _outlineMaterial;
    
    private Shop _shop;

    public void Initialize()
    {
        _shop = new Shop();
    }

    public void Interact()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
