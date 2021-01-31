using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public MovementJoystick m_oMovementJoystick;
    public Camera m_oMainCamera;
    public float m_nMoveSpeed;
    public float m_nRotateSpeed;
    public AnimationStateController m_oAnimationStateController;


    private void Update() {
        Vector3 movementVector = MovementInput();
        RotateTowardMovementVector(movementVector);
    }
    
    private Vector3 MovementInput() {
        float m_oHorizontal = m_oMovementJoystick.m_vJoystickVector.x;
        float m_oVertical = m_oMovementJoystick.m_vJoystickVector.y;
        m_oAnimationStateController.SetAnimationState(m_oHorizontal, m_oVertical);
        Vector3 movement = new Vector3(m_oHorizontal, 0f, m_oVertical);
        transform.Translate(movement * m_nMoveSpeed * Time.deltaTime, Space.World);
        return movement;
    }

    private void RotateTowardMovementVector(Vector3 movementVector) {
        movementVector = Quaternion.Euler(0f, m_oMainCamera.gameObject.transform.eulerAngles.y, 0f) * movementVector;
        if (movementVector.magnitude == 0) { return; } 
        Quaternion rotation = Quaternion.LookRotation(movementVector);
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, m_nRotateSpeed);
    }

}
