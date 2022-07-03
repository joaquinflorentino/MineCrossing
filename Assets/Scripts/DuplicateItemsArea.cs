using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateItemsArea : MonoBehaviour
{
    [SerializeField]
    private GameObject waterItemDuplicate;
    [SerializeField]
    private GameObject stoneItemDuplicate;

    // Start is called before the first frame update
    void Start()
    {
        Transform itemSlot1 = gameObject.transform.GetChild(0);
        Transform itemSlot2 = gameObject.transform.GetChild(1);

        waterItemDuplicate.GetComponent<DragDrop>().FillItemSlot(itemSlot1);
        stoneItemDuplicate.GetComponent<DragDrop>().FillItemSlot(itemSlot2);
        waterItemDuplicate.GetComponent<Item>().SetIsInventoryItem(false);
        stoneItemDuplicate.GetComponent<Item>().SetIsInventoryItem(false);
    }
}
