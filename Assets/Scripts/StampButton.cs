using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampButton : MonoBehaviour
{
    public void SelectStamp() {
        GameObject stampHolder = GameObject.Find("StampHolder");

        stampHolder.GetComponent<StampHolder>().SetIsStampButtonSelected(true);
        stampHolder.transform.GetChild(0).gameObject.SetActive(true);
        stampHolder.GetComponent<SpriteRenderer>().sprite = stampHolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
}
