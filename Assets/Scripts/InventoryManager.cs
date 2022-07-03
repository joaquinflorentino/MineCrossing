using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject plantItem;
    [SerializeField]
    private GameObject fireItem;
    [SerializeField]
    private GameObject waterItem;
    [SerializeField]
    private GameObject earthItem;
    [SerializeField]
    private GameObject stoneItem;
    [SerializeField]
    private GameObject airItem;

    // Start is called before the first frame update
    void Start()
    {
        InitializeIventory();
        GameObject.Find("CraftingCanvas").SetActive(false);
    }

    public void InitializeIventory() {
        Transform itemSlot1 = gameObject.transform.GetChild(0);
        Transform itemSlot2 = gameObject.transform.GetChild(1);
        Transform itemSlot3 = gameObject.transform.GetChild(2);
        Transform itemSlot4 = gameObject.transform.GetChild(3);
        Transform itemSlot5 = gameObject.transform.GetChild(4);
        Transform itemSlot6 = gameObject.transform.GetChild(5);

        plantItem.GetComponent<DragDrop>().FillItemSlot(itemSlot1);
        fireItem.GetComponent<DragDrop>().FillItemSlot(itemSlot2);
        waterItem.GetComponent<DragDrop>().FillItemSlot(itemSlot3);
        earthItem.GetComponent<DragDrop>().FillItemSlot(itemSlot4);
        stoneItem.GetComponent<DragDrop>().FillItemSlot(itemSlot5);
        airItem.GetComponent<DragDrop>().FillItemSlot(itemSlot6);
    }

    public List<string> GetInventory() {
        List<string> inventory = new List<string>();

        foreach (Transform itemSlot in gameObject.transform) {
            if (itemSlot.childCount > 0) {
                inventory.Add(itemSlot.GetChild(0).GetComponent<Item>().GetItemName());
            }
        }
        return inventory;
    }
}
