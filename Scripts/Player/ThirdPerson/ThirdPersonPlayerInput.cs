using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ThirdPersonPlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerSettings _playerSettings;
    private GameObject ingameUI;

    public Vector2 MoveVector { get; private set; }
    public Vector3 MouseDelta { get; private set; }

    //Events
    public delegate void JumpAction();
    public static event JumpAction JumpEvent;

    private void Start()
    {
        if (_playerSettings.ingameUI)
        {
            ingameUI = Instantiate(_playerSettings.ingameUI);
            ingameUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ActionMovement(InputAction.CallbackContext context)
    {
        if(context.performed) 
        {
            MoveVector = context.ReadValue<Vector2>();
        }

        if(context.canceled)
        {
            MoveVector = Vector2.zero;
        }
    }
    public void ActionMouseDelta(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MouseDelta = context.ReadValue<Vector2>();  
        }
        else if (context.canceled)
        {
            MouseDelta = Vector2.zero;
        }
    }
    public void ActionJump(InputAction.CallbackContext context)
    {
        if (context.performed) JumpEvent.Invoke();
    }
    public void ActionPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (ingameUI) ingameUI.SetActive(!ingameUI.activeInHierarchy);
            if(ingameUI.activeInHierarchy) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;
        }
    }
    public void ActionRightHand(InputAction.CallbackContext context)
    {
        if (context.performed) return;
    }
    public void ActionLeftHand(InputAction.CallbackContext context)
    {
        if (context.performed) return;
    }
}