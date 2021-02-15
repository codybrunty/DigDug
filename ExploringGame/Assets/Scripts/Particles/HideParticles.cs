using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideParticles : MonoBehaviour{
    public float hideAfterSeconds;

    void OnEnable(){
        StartCoroutine(HideParticleAfterTime());
    }

    IEnumerator HideParticleAfterTime() {
        yield return new WaitForSeconds(hideAfterSeconds);
        gameObject.SetActive(false);
    }

}
