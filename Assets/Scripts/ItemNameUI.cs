using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemNameUI : MonoBehaviour
{
    private Text ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<Text>();
        gameObject.SetActive(false);
    }

    public void EnableText(string itemName) {
        gameObject.SetActive(true);
        ui.text = itemName;
        GameObject attachedItemSlot = transform.parent.parent.gameObject;
        RectTransform rect = GetComponent<RectTransform>();

        if (attachedItemSlot.CompareTag("BottomRowItemSlot")) {
            rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, -123);
        }
        else {
            rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, 123);
        }
    }
}
