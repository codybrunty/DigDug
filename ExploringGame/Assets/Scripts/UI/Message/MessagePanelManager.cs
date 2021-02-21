using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessagePanelManager : MonoBehaviour{

    public static MessagePanelManager m_oInstance;

    public GameObject m_oMessagePanel;
    public TextMeshProUGUI m_oMessageText;

    private void Awake() {
        m_oInstance = this;
    }

    public void vOpenMessagePanel(string message) {
        m_oMessageText.text = message;
        m_oMessagePanel.SetActive(true);
    }

    public void vCloseMessagePanel() {
        m_oMessagePanel.SetActive(false);
    }

}
