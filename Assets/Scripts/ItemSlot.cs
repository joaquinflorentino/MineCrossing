using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        GameObject item = eventData.pointerDrag;
        GameObject area = transform.parent.gameObject;
        GameObject inventoryArea = GameObject.Find("InventoryArea");
        GameObject duplicateItemsArea = GameObject.Find("DuplicateItemsArea");

        if (item.GetComponent<Item>().IsInventoryItem() && area != duplicateItemsArea || !item.GetComponent<Item>().IsInventoryItem() && area != inventoryArea) {
            item.GetComponent<DragDrop>().FillItemSlot(gameObject.transform);
        }
    }
}
