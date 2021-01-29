using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public Camera m_oMainCamera;
    public float m_nMoveSpeed;
    public float m_nRotateSpeed;



    private void Update() {
        Vector3 movementVector = MovementInput();
        RotateTowardMovementVector(movementVector);
    }
    
    private Vector3 MovementInput() {
        float m_oHorizontal = Input.GetAxis("Horizontal");
        float m_oVertical = Input.GetAxis("Vertical");
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
