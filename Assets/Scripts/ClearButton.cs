using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    private List<GameObject> activeStampsInScene = new List<GameObject>();

    public void UpdateActiveStampsInScene(GameObject stamp) {
        activeStampsInScene.Add(stamp);
    }

    public void ClearStamps() {
        foreach (GameObject stamp in activeStampsInScene) {
            Destroy(stamp);
        }
    }
}
