using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCraftingCanvas : MonoBehaviour
{
    private GameObject craftingCanvasObj;
    private GameObject editingCanvasObj;
    private GameObject stamp;
    private bool isCraftingCanvasEnabled;

    public bool IsCraftingCanvasEnabled() {
        return isCraftingCanvasEnabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        craftingCanvasObj = GameObject.Find("CraftingCanvas");
        editingCanvasObj = GameObject.Find("EditingCanvas");
        stamp = GameObject.Find("StampHolder");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) {
            if (isCraftingCanvasEnabled) {
                craftingCanvasObj.SetActive(false);
                isCraftingCanvasEnabled = false;
                editingCanvasObj.SetActive(true);
                stamp.SetActive(true);
            }
            else {
                craftingCanvasObj.SetActive(true);
                isCraftingCanvasEnabled = true;
                editingCanvasObj.SetActive(false);
                stamp.SetActive(false);
            }
        }
    }
}
