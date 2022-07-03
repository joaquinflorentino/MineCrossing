using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private string itemName;
    private bool isInventoryItem = true;
    [SerializeField]
    private bool hasStamp;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private GameObject itemNameUIObj;

    public string GetItemName() {
        return itemName;
    }

    public bool IsInventoryItem() {
        return isInventoryItem;
    }

    public void SetIsInventoryItem(bool value) {
        isInventoryItem = value;
    }

    public Sprite GetSprite() {
        return GetComponent<Image>().sprite;
    }

    public bool HasStamp() {
        return hasStamp;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        itemNameUIObj.GetComponent<ItemNameUI>().EnableText(itemName);
    }

    public void OnPointerExit(PointerEventData eventData) {
        itemNameUIObj.SetActive(false);
    }

    private void Awake() {
        itemNameUIObj = transform.GetChild(0).gameObject;
    }
}
