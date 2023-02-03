using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/Player")]
public class PlayerSettings : ScriptableObject
{
    [Header("Speed")]
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpHigh;

    [Header("Health")]
    public float maxHealth;

    [Header("Changing variables")]
    public bool shouldMove;
    public bool isFalling;

    [Header("Additional settings")]
    public float gravity = -9.2f;
    public float gravityMultiplier = 3.0f;
    public float enableMovementDelay;

    [Header("Assets")]
    public GameObject ingameUI;

    [Header("Animations")]
    public float walkspeedCompensator;
}
