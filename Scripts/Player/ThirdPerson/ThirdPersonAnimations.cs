using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimations : MonoBehaviour
{
    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim.SetFloat("walkSpeed", _playerSettings.moveSpeed * _playerSettings.walkspeedCompensator);
    }

    private void Update()
    {
        anim.SetBool("shouldMove", _playerSettings.shouldMove);
        anim.SetBool("isFalling", _playerSettings.isFalling);
    }
}
