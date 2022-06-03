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
    InputAction interactAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpInput => jumpBufferTimer > 0;
    [SerializeField] float jumpBufferDuration = 0.2f;
    private float jumpBufferTimer = 0f;

    public bool InteractInput => interactBufferTimer > 0;
    [SerializeField] float interactBufferDuration = 0.2f;
    private float interactBufferTimer = 0f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
        jumpAction = input.actions["Jump"];
        interactAction = input.actions["Interact"];
    }

    private void Update()
    {
        JumpBufferCountdown();
        InteractBufferCountdown();
    }

    private void OnEnable()
    {
        moveAction.started += OnMoveInput;
        moveAction.performed += OnMoveInput;
        moveAction.canceled += OnMoveInput;

        jumpAction.started += OnJumpInput;
        jumpAction.canceled += OnJumpInput;

        interactAction.started += OnInterractAction;
        interactAction.canceled += OnInterractAction;
    }

    private void OnDisable()
    {
        moveAction.started -= OnMoveInput;
        moveAction.performed -= OnMoveInput;
        moveAction.canceled -= OnMoveInput;

        jumpAction.started -= OnJumpInput;
        jumpAction.canceled -= OnJumpInput;

        interactAction.started -= OnInterractAction;
        interactAction.canceled -= OnInterractAction;
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
        if (context.started) { interactBufferTimer = interactBufferDuration; }
    }

    private void InteractBufferCountdown()
    {
        if (interactBufferTimer > 0) { interactBufferTimer -= Time.deltaTime; }
        else { return; }
    }

    public void ClearInteractBuffer() => interactBufferTimer = 0f;
}
