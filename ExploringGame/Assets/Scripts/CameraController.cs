using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_oTargetTransform;
    public Vector3 m_oTargetOffsetVector;
    public float m_nMovementSpeed;

    private void Update() {
        MoveCamera();
    }

    private void MoveCamera() {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, m_oTargetTransform.position+m_oTargetOffsetVector, m_nMovementSpeed*Time.deltaTime);
    }
}
