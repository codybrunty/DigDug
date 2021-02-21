using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public float m_oBulletSpeed;
    private float m_oCurrentSeconds;
    public float m_oMaxSeconds;
    public GameObject m_oOnHitEffect;

    private void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime*m_oBulletSpeed);
        m_oCurrentSeconds += Time.deltaTime;

        if (m_oCurrentSeconds > m_oMaxSeconds) {
            m_oCurrentSeconds = 0f;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "interactiveOBJ") {
            if (obj.gameObject.GetComponent<InteractableObject>().hasGravity) {
                obj.gameObject.GetComponent<InteractableObject>().hasGravity = false;
                ObjectPoolingManager.m_oInstance.oSpawnFromPool("BulletHit", gameObject.transform.position, gameObject.transform.rotation);
                m_oCurrentSeconds = 0f;
                gameObject.SetActive(false);
            }
        }
    }

}
