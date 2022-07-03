using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject brickItem;
    [SerializeField]
    private GameObject benchItem;
    [SerializeField]
    private GameObject earthItem;
    [SerializeField]
    private GameObject fireItem;
    [SerializeField]
    private GameObject houseItem;
    [SerializeField]
    private GameObject airItem;
    [SerializeField]
    private GameObject plantItem;
    [SerializeField]
    private GameObject pondItem;
    [SerializeField]
    private GameObject rainItem;
    [SerializeField]
    private GameObject stoneItem;
    [SerializeField]
    private GameObject toolItem;
    [SerializeField]
    private GameObject treeItem;
    [SerializeField]
    private GameObject waterItem;
    [SerializeField]
    private GameObject woodItem;
    [SerializeField]
    private GameObject benchStamp1;
    [SerializeField]
    private GameObject benchStamp2;
    [SerializeField]
    private GameObject houseStamp;
    [SerializeField]
    private GameObject pondStamp;
    [SerializeField]
    private GameObject stonePathStamp;
    [SerializeField]
    private GameObject treeStamp;

    private string brickItemName;
    private string benchItemName;
    private string earthItemName;
    private string fireItemName;
    private string houseItemName;
    private string airItemName;
    private string plantItemName;
    private string pondItemName;
    private string rainItemName;
    private string stoneItemName;
    private string toolItemName;
    private string treeItemName;
    private string waterItemName;
    private string woodItemName;
    private GameObject stampHolder;
    private Dictionary<List<string>, GameObject> recipes = new Dictionary<List<string>, GameObject>();
    private List<int> indexesOfRecipiesMade = new List<int>();
    private Dictionary<GameObject, List<GameObject>> getStamp = new Dictionary<GameObject, List<GameObject>>();
    private GameObject newStampPopup;
    private GameObject itemsObtainedTracker;
    private int itemsObtainedCount = 6;
    private const int obtainableItemsCount = 14;

    private IEnumerator EnableThenDisableNewStampPopup() {
        newStampPopup.SetActive(true);
        yield return new WaitForSeconds(2);
        newStampPopup.SetActive(false);
    }

    private void OnEnable() {
        newStampPopup.SetActive(false);
    }

    private void Awake() {
        benchStamp1.SetActive(false);
        benchStamp2.SetActive(false);
        houseStamp.SetActive(false);
        pondStamp.SetActive(false);
        stonePathStamp.SetActive(false);
        treeStamp.SetActive(false);
        newStampPopup = GameObject.Find("NewStampPopup");
    }

    // Start is called before the first frame update
    void Start()
    {
        brickItemName = brickItem.GetComponent<Item>().GetItemName();
        benchItemName = benchItem.GetComponent<Item>().GetItemName();
        earthItemName = earthItem.GetComponent<Item>().GetItemName();
        fireItemName = fireItem.GetComponent<Item>().GetItemName();
        houseItemName = houseItem.GetComponent<Item>().GetItemName();
        airItemName = airItem.GetComponent<Item>().GetItemName();
        plantItemName = plantItem.GetComponent<Item>().GetItemName();
        pondItemName = pondItem.GetComponent<Item>().GetItemName();
        rainItemName = rainItem.GetComponent<Item>().GetItemName();
        stoneItemName = stoneItem.GetComponent<Item>().GetItemName();
        toolItemName = toolItem.GetComponent<Item>().GetItemName();
        treeItemName = treeItem.GetComponent<Item>().GetItemName();
        waterItemName = waterItem.GetComponent<Item>().GetItemName();
        woodItemName = woodItem.GetComponent<Item>().GetItemName();
        recipes.Add(new List<string>() {plantItemName, rainItemName}, treeItem);
        recipes.Add(new List<string>() {airItemName, pondItemName}, rainItem);
        recipes.Add(new List<string>() {fireItemName, earthItemName}, brickItem);
        recipes.Add(new List<string>() {brickItemName, toolItemName}, houseItem);
        recipes.Add(new List<string>() {waterItemName, waterItemName}, pondItem);
        recipes.Add(new List<string>() {treeItemName, toolItemName}, woodItem);
        recipes.Add(new List<string>() {stoneItemName, stoneItemName}, toolItem);
        recipes.Add(new List<string>() {woodItemName, toolItemName}, benchItem);
        getStamp.Add(benchItem, new List<GameObject>() {benchStamp1, benchStamp2});
        getStamp.Add(houseItem, new List<GameObject>() {houseStamp});
        getStamp.Add(pondItem, new List<GameObject>() {pondStamp});
        getStamp.Add(stoneItem, new List<GameObject>() {stonePathStamp});
        getStamp.Add(treeItem, new List<GameObject>() {treeStamp});
        stampHolder = GameObject.Find("StampHolder");
        itemsObtainedTracker = GameObject.Find("ItemsObtainedTracker");
        itemsObtainedTracker.GetComponent<ItemsObtainedTracker>().UpdateText(itemsObtainedCount, obtainableItemsCount);
    }

    // Update is called once per frame
    void Update()
    {
        Transform inputSlot1 = transform.GetChild(0).GetChild(0);
        Transform inputSlot2 = transform.GetChild(0).GetChild(1);

        if (inputSlot1.childCount > 0 && inputSlot2.childCount > 0) {
            string item1Name = inputSlot1.GetChild(0).gameObject.GetComponent<Item>().GetItemName();
            string item2Name = inputSlot2.GetChild(0).gameObject.GetComponent<Item>().GetItemName();
            int offset = -1;
            int index = 0 + offset;

            foreach (KeyValuePair<List<string>, GameObject> recipe in recipes) {
                List<string> inputItems = recipe.Key;
                index++;

                if (indexesOfRecipiesMade.Contains(index)) {
                    continue;
                }

                if (inputItems.Contains(item1Name) && inputItems.Contains(item2Name)) {
                    Transform outputArea = transform.GetChild(1);
                    GameObject outputItem = recipes[inputItems];

                    outputItem.GetComponent<Item>().SetIsInventoryItem(true);
                    outputItem.GetComponent<DragDrop>().FillItemSlot(outputArea);
                    indexesOfRecipiesMade.Add(index);

                    if (getStamp.ContainsKey(outputItem)) {
                        stampHolder.GetComponent<StampHolder>().AddStamp(getStamp[outputItem]);
                    }
                    if (outputItem.GetComponent<Item>().HasStamp()) {
                        StartCoroutine(EnableThenDisableNewStampPopup());
                    }
                    itemsObtainedCount++;
                    itemsObtainedTracker.GetComponent<ItemsObtainedTracker>().UpdateText(itemsObtainedCount, obtainableItemsCount);
                    break;
                }
            }
        }
    }
}
