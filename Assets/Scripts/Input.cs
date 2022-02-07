using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public Vector2 moveDirection { get; private set; }
    private InputActions _inputActions;

    private void Awake() => _inputActions = new InputActions();

    private void Update()
    { 
        moveDirection = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();
}