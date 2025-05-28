using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkAcceleration = 10f;
    [SerializeField] private float _runAcceleration = 25f;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 25f;
    [SerializeField] private float _deceleration = 2f;
    [SerializeField] private float _drag = 2f;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _rotateDrag = 0.1f;

    [Header("Physic")]
    [SerializeField] private float _gravity = 9.8f;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _sprintAction;
    [SerializeField] private InputActionReference _lookAction;

    [Header("Camera")]
    [SerializeField] private Camera _camera;


    private Vector3 _moveDir;
    private CharacterController _characterController;
    private bool _isRunning = false;

    public void Initialize()
    {
        _characterController = GetComponent<CharacterController>();
        _sprintAction.action.performed += OnSprintPressed;
    }

    private void OnSprintPressed(InputAction.CallbackContext context)
    {
        _isRunning = !_isRunning;
    }

    private void FixedUpdate()
    {
        Rotate();
        Gravity();
        Move();
    }

    private void Move()
    {
        var inputDir = _moveAction.action.ReadValue<Vector2>();
        _moveDir = new Vector3(inputDir.x, 0f, inputDir.y);

        var currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
        var currentAcceleration = _isRunning ? _runAcceleration : _walkAcceleration;

        var movementDelta = _moveDir * currentAcceleration * Time.fixedDeltaTime;
        var newVelocity = _characterController.velocity + movementDelta;

        Vector3 currentDrag = newVelocity.normalized * _drag;
        newVelocity = newVelocity.magnitude > _drag ? newVelocity - currentDrag : Vector3.zero;
        newVelocity = Vector3.ClampMagnitude(newVelocity, currentSpeed);

        _characterController.Move(newVelocity * Time.fixedDeltaTime);
    }

    private void Gravity()
    {

    }

    private void Rotate()
    {
        
        var cursorPosition = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        if (Physics.Raycast(cursorPosition, out RaycastHit hitInfo))
        {
            Vector3 direction = (hitInfo.point - transform.position).normalized;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}
