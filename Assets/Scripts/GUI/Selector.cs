using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    [SerializeField] private List<ButtonAnimation> _buttons;
    [SerializeField] private InputActionReference _navigateAction;

    public void OnEnable()
    {
        _navigateAction.action.performed += HandleNavigation;
    }

    public void OnDisable()
    {
        _navigateAction.action.performed -= HandleNavigation;
    }

    private void HandleNavigation(InputAction.CallbackContext context)
    {
        ButtonAnimation button;
        int dir = Mathf.RoundToInt(context.ReadValue<Vector2>().y);

        if (_buttons.Count(button=>button.IsHighlighted) == 0)
        {
            button = _buttons.FirstOrDefault(button => button.gameObject.activeSelf);   
        }
        else
        {
            button = _buttons[(_buttons.IndexOf(_buttons.FirstOrDefault(button => button.IsHighlighted)) + dir) % _buttons.Count];
        }

        button.Highlight();

        /*foreach (var but in _buttons)
        {
            but.UnHighlight();
        }*/

        Debug.Log(dir);
    }
}
