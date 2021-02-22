using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerActionRange : MonoBehaviour{

    List<GameItem> collectableItemsInRange = new List<GameItem>();
    public int itemCount;
    public TextMeshProUGUI itemCountText;
    public Button messagePanelButton;

    private void OnTriggerEnter(Collider other) {
        GameItem item = other.GetComponent<GameItem>();
        if (item != null) {
            if (item.m_oIsCollectable) {
                collectableItemsInRange.Add(item);
                messagePanelButton.onClick.RemoveAllListeners();
                messagePanelButton.onClick.AddListener(vPickUpCollectableItem);
                MessagePanelManager.m_oInstance.vOpenMessagePanel("Tap To Pick Up " + item.m_oItemName);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        GameItem item = other.GetComponent<GameItem>();
        if (item != null) {
            if (item.m_oIsCollectable) {
                collectableItemsInRange.Remove(item);
                CheckMessagePanelCloseable();
            }
        }
    }

    public void vPickUpCollectableItem() {
        if(collectableItemsInRange.Count > 0) {
            if (!PlayerManager.m_oInstance.m_oPlayerAnimator.GetBool("isDead")) {
                itemCount++;
                itemCountText.text = itemCount.ToString();

                int index = nClosestIndex();
                collectableItemsInRange[index].vPickUp();
                collectableItemsInRange.RemoveAt(index);
                
                
                CheckMessagePanelCloseable();
            }
        }
    }

    private int nClosestIndex() {
        int savedIndex = 0;

        float smallestDistance = 0;
        for (int i = 0; i < collectableItemsInRange.Count; i++) {
            float distance = (collectableItemsInRange[i].transform.position - gameObject.transform.position).sqrMagnitude;
            Debug.Log(distance);
            if(smallestDistance == 0 || distance < smallestDistance) {
                smallestDistance = distance;
                savedIndex = i;
            }
        }

        return savedIndex;
    }

    private void CheckMessagePanelCloseable() {
        if (collectableItemsInRange.Count == 0) {
            MessagePanelManager.m_oInstance.vCloseMessagePanel();
        }
    }
}
