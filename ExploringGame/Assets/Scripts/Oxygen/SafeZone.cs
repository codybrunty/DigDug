using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour{


    private void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Player") {
            Debug.Log("Player Entered Safe Zone");
            PlayerController.m_oInstance.inSafeZone = true;
        }
    }


    private void OnTriggerExit(Collider obj) {
        if (obj.tag == "Player") {
            Debug.Log("Player Exited Safe Zone");
            PlayerController.m_oInstance.inSafeZone = false;
        }
    }


}
