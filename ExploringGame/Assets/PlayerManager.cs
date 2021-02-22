using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour{

    public static PlayerManager m_oInstance;

    public GameObject m_oPlayer;
    public PlayerAnimationStateController m_oPlayerAnimationStateController;
    public Animator m_oPlayerAnimator;
    public Joystick m_oPlayerJoystick;
    public PlayerMovement m_oPlayerMovement;
    public PlayerAttributes m_oPlayerAttributes;
    public Rigidbody m_oPlayerRigidBody;
    public CharacterController m_oPlayerController;

    private void Awake() {
        m_oInstance = this;
    }



}
