using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenManager : MonoBehaviour{

    public static OxygenManager m_oInstance;

    [Header("Slider Information")]
    public int m_nOxygenLevel = 1;
    private List<float> m_lstOxygenLevelPercentages = new List<float>() { 0f, 0.25f,0.5f,0.75f,1.0f };
    public float m_fCurrentOxygen;
    public float m_fMaxOxygen;

    [Header("Slider Mechanics")]
    public float m_fOxygenLossCoefficient = 0.001f;
    public float m_fOxygenGainCoefficient = 0.05f;

    [Header("Game Components")]
    public Image m_iSliderBackground;
    public Image m_iSliderForeground;
    public TextMeshProUGUI m_tOxygenDisplay;

    private void Awake() {
        m_oInstance = this;
    }

    private void Start() {
        vResetOxygenValuesToLevel();
        vSetOxygenDisplay();
    }

    private void Update() {
        if (!PlayerController.m_oInstance.inSafeZone) {
            vRemoveOxygen();
            vSetOxygenDisplay();
        }
        else {
            vAddOxygen();
            vSetOxygenDisplay();
        }

    }

    private void vRemoveOxygen() {
        m_fCurrentOxygen -= m_fOxygenLossCoefficient * Time.deltaTime;
        if(m_fCurrentOxygen < 0f) {
            m_fCurrentOxygen = 0f;
            PlayerAnimationStateController.m_oInstance.vSetDeathAnimationState();
            PlayerController.m_oInstance.vPlayerDead();
        }
    }

    private void vAddOxygen() {
        m_fCurrentOxygen += m_fOxygenGainCoefficient * Time.deltaTime;
        if (m_fCurrentOxygen > m_fMaxOxygen) {
            m_fCurrentOxygen = m_fMaxOxygen;
        }
    }


    #region Slider Display

    public void vSetOxygenDisplay() {
        vSetOxygenDisplayImages();
        vSetOxygenDisplayText();
    }

    public void vSetOxygenDisplayImages() {
        m_iSliderBackground.fillAmount = m_fMaxOxygen;
        m_iSliderForeground.fillAmount = m_fCurrentOxygen;
    }

    public void vSetOxygenDisplayText() {
        int percentageNumber = (int) (((m_fCurrentOxygen) / (m_fMaxOxygen)) * 100);
        m_tOxygenDisplay.text = "O2: " + percentageNumber.ToString() + "%";
    }
    #endregion

    #region Reset Slider Values
    public void vResetOxygenValuesToLevel() {
        m_fMaxOxygen = m_lstOxygenLevelPercentages[m_nOxygenLevel];
        m_fCurrentOxygen = m_fMaxOxygen;
    }
    #endregion

}
