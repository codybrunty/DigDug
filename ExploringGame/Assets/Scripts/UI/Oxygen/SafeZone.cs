using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour{

    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Player") {
            Debug.Log("Player Entered Safe Zone");
            PlayerManager.m_oInstance.m_oPlayerAttributes.inSafeZone = true;
        }
    }


    private void OnTriggerExit(Collider obj) {
        if (obj.tag == "Player") {
            Debug.Log("Player Exited Safe Zone");
            PlayerManager.m_oInstance.m_oPlayerAttributes.inSafeZone = false;
        }
    }


}
