using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public static PlayerController m_oInstance;

    [Header("Player Information")]
    public bool inSafeZone;

    [Header("Player Movement")]
    public Joystick m_oJoystick;
    public Camera m_oMainCamera;
    public float m_fCurrentMoveSpeed;
    public float m_fCurrentRotateSpeed;
    [SerializeField]private float m_fBaseMoveSpeed;
    [SerializeField]private float m_fBaseRotateSpeed;

    private void Awake() {
        m_oInstance = this;
    }

    private void Start() {
        m_fCurrentMoveSpeed = m_fBaseMoveSpeed;
        m_fCurrentRotateSpeed = m_fBaseRotateSpeed;
    }

    private void Update() {
        Vector3 movementVector = MovementInput();
        RotateTowardMovementVector(movementVector);
    }
    
    private Vector3 MovementInput() {
        float m_oHorizontal = m_oJoystick.Horizontal;
        float m_oVertical = m_oJoystick.Vertical;
        PlayerAnimationStateController.m_oInstance.SetAnimationState(m_oHorizontal, m_oVertical);
        Vector3 movement = new Vector3(m_oHorizontal, 0f, m_oVertical);
        transform.Translate(movement * m_fCurrentMoveSpeed * Time.deltaTime, Space.World);
        return movement;
    }

    private void RotateTowardMovementVector(Vector3 movementVector) {
        movementVector = Quaternion.Euler(0f, m_oMainCamera.gameObject.transform.eulerAngles.y, 0f) * movementVector;
        if (movementVector.magnitude == 0) { return; } 
        Quaternion rotation = Quaternion.LookRotation(movementVector);
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, m_fCurrentRotateSpeed);
    }

    public void vPlayerDead() {
        m_fCurrentMoveSpeed = 0f;
        m_fCurrentRotateSpeed = 0f;
    }

    public void vPlayerInjured() {
        m_fCurrentMoveSpeed = m_fBaseMoveSpeed/4f;
        m_fCurrentRotateSpeed = m_fBaseRotateSpeed/4f;
    }

    public void vPlayerHealthy() {
        m_fCurrentMoveSpeed = m_fBaseMoveSpeed;
        m_fCurrentRotateSpeed = m_fBaseRotateSpeed;
    }

}
