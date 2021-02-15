using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour{

    public GameObject m_tBulletSpawnPoint;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    private void Shoot() {
        ObjectPoolingManager.m_oInstance.oSpawnFromPool("BulletFlash", m_tBulletSpawnPoint.transform.position, m_tBulletSpawnPoint.transform.rotation);
        ObjectPoolingManager.m_oInstance.oSpawnFromPool("Bullet", m_tBulletSpawnPoint.transform.position, m_tBulletSpawnPoint.transform.rotation);
    }
    
}
