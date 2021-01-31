using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour{

    public Animator m_oPlayerAnimator;

    public void SetAnimationState(float x, float y) {
        if(x==0 && y == 0) {
            IdleAnimation();
        }
        else {
            RunningAnimation();
        }
    }

    public void RunningAnimation() {
        if (!m_oPlayerAnimator.GetBool("isRunning")) {
            m_oPlayerAnimator.SetBool("isRunning", true);
        }
    }

    public void IdleAnimation() {
        if (m_oPlayerAnimator.GetBool("isRunning")) {
            m_oPlayerAnimator.SetBool("isRunning", false);
        }
    }

}
