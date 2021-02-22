using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour{

    public float m_fLookRadius;

    private Transform m_oTarget;
    private NavMeshAgent m_oAgent;
    private EnemyCombat m_oEnemyCombat;
    private InteractableObject m_oInteractableObject;

    private void Start() {
        m_oTarget = PlayerManager.m_oInstance.m_oPlayer.transform;
        m_oAgent = gameObject.GetComponent<NavMeshAgent>();
        m_oEnemyCombat = gameObject.GetComponent<EnemyCombat>();
        m_oInteractableObject = gameObject.GetComponent<InteractableObject>();
    }

    private void Update() {
        if (m_oInteractableObject.hasGravity) {
            float distance = Vector3.Distance(m_oTarget.position, gameObject.transform.position);
            if (distance <= m_fLookRadius) {
                m_oAgent.SetDestination(m_oTarget.position);
                if (distance <= m_oAgent.stoppingDistance) {
                    vFaceTarget();
                    m_oEnemyCombat.vAttack();
                }
            }
        }
    }

    private void vFaceTarget() {
        Vector3 direction = (m_oTarget.position - gameObject.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    public void vImmobilize() {
        m_oAgent.enabled = false;
        m_oEnemyCombat.m_oAttackMode = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position,m_fLookRadius);
    }

}
