using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour{

    public bool m_oAttackMode = true;
    public float m_oDamage;
    public float m_oAttackSpeed = 1f;
    private float m_oAttackCooldown = 0f;

    private void Update() {
        m_oAttackCooldown -= Time.deltaTime;
    }

    public void vAttack() {
        if(m_oAttackCooldown <= 0f && m_oAttackMode) {
            Debug.Log(gameObject.transform.name + " attacks for "+ m_oDamage);
            OxygenManager.m_oInstance.vRemoveOxygen(m_oDamage);
            m_oAttackCooldown = 1f / m_oAttackSpeed;
        }
    }

}
