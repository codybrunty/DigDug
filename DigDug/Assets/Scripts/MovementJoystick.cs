using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MovementJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler{

    public GameObject m_oJoystick;
    public GameObject m_oJoystickBackground;
    public Vector2 m_vJoystickVector;
    public Vector2 m_vJoystickTouchPosition;
    public Vector2 m_vJoystickOriginalPosition;
    public float m_nJoystickRadius;

    private void Start() {
        m_vJoystickOriginalPosition = m_oJoystickBackground.transform.position;
        m_nJoystickRadius = m_oJoystickBackground.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void OnPointerDown(PointerEventData eventData) {
        m_oJoystick.transform.position = Input.mousePosition;
        m_oJoystickBackground.transform.position = Input.mousePosition;
        m_vJoystickTouchPosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData) {
        m_vJoystickVector = Vector2.zero;
        m_oJoystick.transform.position = m_vJoystickOriginalPosition;
        m_oJoystickBackground.transform.position = m_vJoystickOriginalPosition;
    }

    public void OnDrag(PointerEventData pointerEventData) {
        Vector2 dragPosition = pointerEventData.position;
        m_vJoystickVector = (dragPosition - m_vJoystickTouchPosition).normalized;

        float joystickDistance = Vector2.Distance(dragPosition, m_vJoystickTouchPosition);
        if (joystickDistance < m_nJoystickRadius) {
            m_oJoystick.transform.position = m_vJoystickTouchPosition + m_vJoystickVector * joystickDistance;
        }
        else {
            m_oJoystick.transform.position = m_vJoystickTouchPosition + m_vJoystickVector * m_nJoystickRadius;
        }
    }
}
