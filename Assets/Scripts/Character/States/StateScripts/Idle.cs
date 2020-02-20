﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/Idle")]
public class Idle : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
        anim = charControl.GetComponent<Animator>();
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if(charControl.isJumping)
        {
            anim.SetBool("isJumping", true);
        }


        if (charControl.isMoving)
        {
            anim.SetBool("isRunning", true);
            return;
        }
        else
        {
            anim.SetFloat("velX", 0);
            anim.SetFloat("velZ", 0);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = null;
        anim = null;
    }
}
