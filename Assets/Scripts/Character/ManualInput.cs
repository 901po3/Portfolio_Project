﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharacterControl charControl;
    private Animator animator;

    #region Input Actions
    private PlayerInputAction playerInputAction;
    private Vector2 playerAxis;
    private bool jumpInput;
    #endregion

    private void Awake()
    {
        charControl = gameObject.GetComponent<CharacterControl>();
        animator = gameObject.GetComponent<Animator>();
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerContols.Move.performed += ctx => playerAxis = ctx.ReadValue<Vector2>();
        playerInputAction.PlayerContols.Jump.performed += ctx => jumpInput = true;
        playerInputAction.PlayerContols.Jump.canceled += ctx => jumpInput = false;
    }

    private void Update()
    {
        Moving();
        Jumping();
    }

    private void Moving()
    {
        charControl.isMoving = (playerAxis != Vector2.zero) ? true : false;
        charControl.isMovingForward = (playerAxis.y > 0) ? true : false;
        charControl.isMovingBackward = (playerAxis.y < 0) ? true : false;
        charControl.isMovingRight = (playerAxis.x > 0) ? true : false;
        charControl.isMovingLeft = (playerAxis.x < 0) ? true : false;

        animator.SetFloat("velX", Input.GetAxis("Horizontal"));
        animator.SetFloat("velZ", Input.GetAxis("Vertical"));
    }

    private void Jumping()
    {
        if(jumpInput && !charControl.isJumping)
        {
            jumpInput = false;
            charControl.isJumping = true;
        }
        else
        {
            charControl.isJumping = false;
        }
    }

    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    private void OnDisable()
    {
        playerInputAction.Disable();
    }

}
