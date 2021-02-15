using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour{
    public void vResetButtonOnClick() {
        OxygenManager.m_oInstance.vResetOxygenValuesToLevel();
        PlayerAnimationStateController.m_oInstance.AliveAnimationState();
        PlayerController.m_oInstance.vPlayerHealthy();
    }

}
