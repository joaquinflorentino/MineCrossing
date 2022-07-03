using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    private bool isItemAttachedToSlot;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetIsItemAttachedToSlot(bool value) {
        isItemAttachedToSlot = value;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (isItemAttachedToSlot) {
            if (transform.position != transform.parent.transform.position) {
                transform.SetParent(null);
                isItemAttachedToSlot = false;
            }
        }
    }

    public void FillItemSlot(Transform itemSlot) {
        gameObject.SetActive(true);

        if (itemSlot.childCount > 0) {
            itemSlot.GetChild(0).SetParent(GameObject.Find("CraftingCanvas").transform);
        }
        gameObject.transform.position = itemSlot.transform.position;
        transform.SetParent(itemSlot);
    }
}
