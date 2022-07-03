using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsObtainedTracker : MonoBehaviour
{
    public void UpdateText(int itemsObtainedCount, int obtainableItemsCount) {
        GetComponent<Text>().text = itemsObtainedCount + "/" + obtainableItemsCount;
    }
}
