
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private Spell _currentSpell;
    [SerializeField] private Camera _camera;
    [SerializeField] private InputActionReference _attackAction;
    [SerializeField] private Transform _castPoint;

    public void Initialize()
    {

    }

    private void OnEnable()
    {
        _attackAction.action.performed += OnAttackPerformed;
    }

    private void OnDisable()
    {
        _attackAction.action.performed -= OnAttackPerformed;
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        var cursorPosition = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        if (Physics.Raycast(cursorPosition, out RaycastHit hitInfo))
        {
            var spell = Instantiate(_currentSpell, _castPoint.position, Quaternion.identity);
            spell.Initialize();
            spell.Cast((hitInfo.point - transform.position).normalized);
        }
    }
}
