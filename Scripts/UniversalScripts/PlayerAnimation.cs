using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator= GetComponent<Animator>();
    }
    public void walk(bool move)
    {
        if (move)
        {
            animator.SetBool(AnimationTags.MOVEMENT, true);
        }
        else
        {
            animator.SetBool(AnimationTags.MOVEMENT, false);
        }
    }

    public void punch1()
    {
        animator.SetTrigger(AnimationTags.PUNCH1_TRIGGER);
    }

    public void punch2()
    {
        animator.SetTrigger(AnimationTags.PUNCH2_TRIGGER);
    }

    public void punch3()
    {
        animator.SetTrigger(AnimationTags.PUNCH3_TRIGGER);
    }

    public void kick1()
    {
        animator.SetTrigger(AnimationTags.KICK1_TRIGGER);
    }

    public void kick2()
    {
        animator.SetTrigger(AnimationTags.KICK2_TRIGGER);
    }

    public void death()
    {
        animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

    //Enemy Animations
    public void enemyAttack(int attack)
    {
        if (attack == 0)
        {
            animator.SetTrigger(AnimationTags.ATTACK1_TRIGGER);
        }
        else if(attack == 1)
        {
            animator.SetTrigger(AnimationTags.ATTACK2_TRIGGER);
        }
        else if (attack == 2)
        {
            animator.SetTrigger(AnimationTags.ATTACK3_TRIGGER);
        }
    }

    public void playIdleAnimation()
    {
        animator.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void knockDown()
    {
        animator.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void hit()
    {
        animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void standUp()
    {
        animator.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }

    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
