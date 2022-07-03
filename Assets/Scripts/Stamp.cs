using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    [SerializeField]
    private string stampName;

    private void OnMouseDown() {
        if (!GameObject.Find("ToggleCraftingCanvas").GetComponent<ToggleCraftingCanvas>().IsCraftingCanvasEnabled()) {
            if (!GameObject.Find("StampHolder").GetComponent<StampHolder>().IsStampButtonSelected()) {
                Destroy(gameObject);
            }
        }
    }

    public string GetStampName() {
        return stampName;
    }
}
