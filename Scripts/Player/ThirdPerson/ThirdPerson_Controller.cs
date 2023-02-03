using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ThirdPersonPlayerInput))]
public class ThirdPerson_Controller : MonoBehaviour
{
    private ThirdPersonPlayerInput input;

    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform cameraBoomVertical;
    [SerializeField] private Transform cameraBoomHorizontal;
    [SerializeField] private Transform playerCharacter;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Vector2 clampedRotation;
    private bool _gameStarted = false;
    private float _velocity;
    private Vector3 _direction;
    private float currentJump;

    private void OnEnable()
    {
        ThirdPersonPlayerInput.JumpEvent += Jump;
    }

    private void OnDisable()
    {
        ThirdPersonPlayerInput.JumpEvent -= Jump;
    }

    private IEnumerator Start()
    {
        _characterController = GetComponent<CharacterController>(); 
        input = GetComponent<ThirdPersonPlayerInput>();
        yield return new WaitForSeconds(_playerSettings.enableMovementDelay);
        _gameStarted= true;
    }
    private void Update()
    {
        if (!_gameStarted) return;
        ApplyGravity();
        _playerSettings.shouldMove = input.MoveVector.magnitude > 0;
        if (_playerSettings.shouldMove) MoveCharacter();
        if (input.MouseDelta.magnitude > 0) RotateCamera();

        if (!_characterController.isGrounded)
        {
            _playerSettings.isFalling = true;
            _velocity += _playerSettings.gravity * _playerSettings.gravityMultiplier * Time.deltaTime;
            currentJump += _playerSettings.gravity * Time.deltaTime;
        }
        else
        {
            if (_playerSettings.isFalling) currentJump = 0;
            _playerSettings.isFalling = false;
            _velocity = -1.0f;
        }
        _direction.y = _velocity + currentJump;

        if (_playerSettings.shouldMove)
        {
            RotateCharacter();
        }
    }
    private void ApplyGravity()
    {
        Vector3 fall = new Vector3(0, _direction.y, 0);
        _characterController.Move(fall * Time.deltaTime);
    }
    private void MoveCharacter()
    {
        Vector3 forward;
        forward = playerCharacter.forward * Mathf.Clamp(Mathf.Abs(input.MoveVector.y) + Mathf.Abs(input.MoveVector.x), 0, 1);
        _direction = forward;
        _characterController.Move(_direction * _playerSettings.moveSpeed * Time.deltaTime);
    }
    private void RotateCamera()
    {
        Quaternion vertical = Quaternion.Euler(input.MouseDelta.y * _playerSettings.rotationSpeed, 0, 0);
        Quaternion horizontal = Quaternion.Euler(0, input.MouseDelta.x * _playerSettings.rotationSpeed, 0);
        Quaternion finalVertical = vertical * cameraBoomVertical.localRotation;
        cameraBoomHorizontal.rotation = horizontal * cameraBoomHorizontal.rotation;
        finalVertical.x = Mathf.Clamp(finalVertical.x, clampedRotation.x, clampedRotation.y);
        cameraBoomVertical.localRotation = finalVertical;
    }
    private void Jump()
    {
        currentJump = _playerSettings.jumpHigh;
    }
    private void RotateCharacter()
    {
        Quaternion addSmall = Quaternion.Euler(1, input.MoveVector.x * 90f, 1);
        Quaternion final = cameraBoomHorizontal.rotation * addSmall;
        if (input.MoveVector.y < 0) final *= Quaternion.Euler(1, 180f, 1);
        else final *= Quaternion.Euler(1, 1, 1);
        playerCharacter.rotation = Quaternion.Slerp(playerCharacter.rotation, final, 30f * Time.deltaTime);
    }
}