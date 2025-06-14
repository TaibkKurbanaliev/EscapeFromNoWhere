using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InputActionReference _interactAction;

    private IInteractable _lastInteractableObject;

    private void OnEnable()
    {
        _interactAction.action.started += OnInteractObject;
    }

    private void OnDisable()
    {
        _interactAction.action.started -= OnInteractObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            _lastInteractableObject = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            _lastInteractableObject = null;
        }
    }

    private void OnInteractObject(InputAction.CallbackContext context)
    {
        if (_lastInteractableObject == null)
            return;

        _lastInteractableObject.Interact();
    }
}
