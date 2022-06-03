using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerInput input;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction interractAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpInput => jumpBufferTimer > 0;
    [SerializeField] float jumpBufferDuration = 0.2f;
    private float jumpBufferTimer = 0f;

    public bool InterractInput => interractBufferTimer > 0;
    [SerializeField] float interractBufferDuration = 0.2f;
    private float interractBufferTimer = 0f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
        jumpAction = input.actions["Jump"];
        interractAction = input.actions["Interract"];
    }

    private void Update()
    {
        JumpBufferCountdown();
        InterractBufferCountdown();
    }

    private void OnEnable()
    {
        moveAction.started += OnMoveInput;
        moveAction.performed += OnMoveInput;
        moveAction.canceled += OnMoveInput;

        jumpAction.started += OnJumpInput;
        jumpAction.canceled += OnJumpInput;

        interractAction.started += OnInterractAction;
        interractAction.canceled += OnInterractAction;
    }

    private void OnDisable()
    {
        moveAction.started -= OnMoveInput;
        moveAction.performed -= OnMoveInput;
        moveAction.canceled -= OnMoveInput;

        jumpAction.started -= OnJumpInput;
        jumpAction.canceled -= OnJumpInput;

        interractAction.started -= OnInterractAction;
        interractAction.canceled -= OnInterractAction;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started) { jumpBufferTimer = jumpBufferDuration; }
    }

    private void JumpBufferCountdown()
    {
        if (jumpBufferTimer > 0) { jumpBufferTimer -= Time.deltaTime; }
        else { return; }
    }

    public void ClearJumpBuffer() => jumpBufferTimer = 0f;

    private void OnInterractAction(InputAction.CallbackContext context)
    {
        if (context.started) { interractBufferTimer = interractBufferDuration; }
    }

    private void InterractBufferCountdown()
    {
        if (interractBufferTimer > 0) { interractBufferTimer -= Time.deltaTime; }
        else { return; }
    }

    public void ClearInterractBuffer() => interractBufferTimer = 0f;
}
