using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimations : MonoBehaviour
{
   Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void AnimationMove(float horizontal)
    {
        _animator.SetFloat("Speed", Mathf.Abs(horizontal));

    }
    public void AnimationJump(bool trueorfalse)
    {
        _animator.SetBool("Jump", trueorfalse);
    }
    public void AnimationClimb(bool trueorfalse)
    {
        _animator.SetBool("Climb", trueorfalse); 
    }

    public void AnimationDeath(bool trueorfalse)
    {
        _animator.SetBool("Death", trueorfalse);
    }

}
