using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour{
    public void vResetButtonOnClick() {
        OxygenManager.m_oInstance.vResetOxygenValuesToLevel();
        PlayerManager.m_oInstance.m_oPlayerAnimationStateController.AliveAnimationState();
        //PlayerManager.m_oInstance.m_oPlayerController.vPlayerHealthy();
    }

}
