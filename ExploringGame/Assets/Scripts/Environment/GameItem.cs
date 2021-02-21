using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour{

    public string m_oItemName;
    public bool m_oIsCollectable;

    public void vPickUp() {
        gameObject.SetActive(false);
    }

}
