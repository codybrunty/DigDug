using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    public GameObject m_oButtonImg;
    public GunController gunController;

    private void Start() {
        m_oButtonImg.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData) {
        m_oButtonImg.gameObject.transform.position = eventData.position;
        m_oButtonImg.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData) {
        gunController.Shoot();
        m_oButtonImg.SetActive(false);
    }
}
