using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedStampText : MonoBehaviour
{
    public void UpdateText(string stampName) {
        GetComponent<Text>().text = "Stamp: " + stampName;
    }
}
