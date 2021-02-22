using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour{

    [Header("Player Movement")]
    public float m_fMoveSpeed;
    public float m_fRotationSpeed;
    private Vector3 m_vVelocity;

    public bool m_bIsGrounded;
    public float m_fGroundCheckDistance;
    public LayerMask m_oGroundMask;
    public float m_fGravity;
    public float m_fJumpHieght;
    public float m_fJetForce;

    private Camera m_oMainCamera;
    private Joystick m_oPlayerJoystick;
    private CharacterController m_oCharacterController;
    private PlayerAnimationStateController m_oPlayerAnimationStateController;

    private void Start() {
        m_oMainCamera = Camera.main;
        m_oPlayerJoystick = PlayerManager.m_oInstance.m_oPlayerJoystick;
        m_oCharacterController = PlayerManager.m_oInstance.m_oPlayerController;
        m_oPlayerAnimationStateController = PlayerManager.m_oInstance.m_oPlayerAnimationStateController;
    }

    private void Update() {
        Vector3 movementVector = MovementInput(m_oPlayerJoystick.Horizontal, m_oPlayerJoystick.Vertical);
        RotateTowardMovementVector(movementVector);
    }

    private float takeoff = 0f;
    private Vector3 MovementInput(float hor, float vert) {
        Vector3 movementDirection = new Vector3(hor, 0f, vert);
        vCheckIsGrounded();

        if (m_bIsGrounded) {
            m_oPlayerAnimationStateController.GroundedAnimation();
            m_oPlayerAnimationStateController.SetAnimationState(hor, vert);
            movementDirection *= m_fMoveSpeed;
        }
        else {
            m_oPlayerAnimationStateController.UnGroundedAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            takeoff = 0f;
            m_oPlayerAnimationStateController.FlyingAnimation();
        }
        if (Input.GetKey(KeyCode.Space)) {
            takeoff += Time.deltaTime;
            if(takeoff > 0.5f) {
                vJetpack();
            }


        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            m_oPlayerAnimationStateController.FallingAnimation();
        }

        m_oCharacterController.Move(movementDirection * Time.deltaTime);
        m_vVelocity.y += m_fGravity * Time.deltaTime;
        m_oCharacterController.Move(m_vVelocity * Time.deltaTime);

        return movementDirection;
    }

    private void vCheckIsGrounded() {
        m_bIsGrounded = Physics.CheckSphere(transform.position, m_fGroundCheckDistance, m_oGroundMask);
        if (m_bIsGrounded && m_vVelocity.y < 0) {
            m_vVelocity.y = -2f;
        }
    }

    private void RotateTowardMovementVector(Vector3 movementVector) {
        movementVector = new Vector3(movementVector.x,0f,movementVector.z);
        movementVector = Quaternion.Euler(0f, m_oMainCamera.gameObject.transform.eulerAngles.y, 0f) * movementVector;
        if (movementVector.magnitude == 0) { return; }
        Quaternion rotation = Quaternion.LookRotation(movementVector);
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, m_fRotationSpeed);
    }

    private void vJetpack() {
        m_vVelocity.y = Mathf.Sqrt(m_fJumpHieght * -2 * m_fGravity);
    }

}
