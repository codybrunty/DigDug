using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour{
    public static PlayerAnimationStateController m_oInstance;
    public Animator m_oPlayerAnimator;

    private void Awake() {
        m_oInstance = this;
    }

    public void SetAnimationState(float x, float y) {
        if(x == 0f && y == 0f) {
            IdleAnimation();
        }
        else {
            MovingAnimation(x,y);
        }

    }

    public void MovingAnimation(float x, float y) {
        if (!m_oPlayerAnimator.GetBool("isMoving")) {
            m_oPlayerAnimator.SetBool("isMoving", true);
        }

        if (Mathf.Abs(x) < 0.4f && Mathf.Abs(y) < 0.4f) {
            WalkAnimation();
        }
        else {
            RunningAnimation();
        }
    }

    public void WalkAnimation() {
        if (m_oPlayerAnimator.GetBool("isRunning")) {
            m_oPlayerAnimator.SetBool("isRunning", false);
        }
    }
    public void RunningAnimation() {
        if (!m_oPlayerAnimator.GetBool("isRunning")) {
            m_oPlayerAnimator.SetBool("isRunning", true);
        }
    }

    public void IdleAnimation() {
        if (m_oPlayerAnimator.GetBool("isMoving")) {
            m_oPlayerAnimator.SetBool("isMoving", false);
        }
        if (m_oPlayerAnimator.GetBool("isRunning")) {
            m_oPlayerAnimator.SetBool("isRunning", false);
        }
    }



    #region Death
    public void vSetDeathAnimationState() {
        if (!m_oPlayerAnimator.GetBool("isDead")) {
            m_oPlayerAnimator.SetInteger("deaths", UnityEngine.Random.Range(0, 4));
            m_oPlayerAnimator.SetBool("isDead", true);
            m_oPlayerAnimator.SetBool("isRunning", false);
        }
    }

    //for testing
    public void AliveAnimationState() {
        m_oPlayerAnimator.SetBool("isDead", false);
    }

    #endregion
}
