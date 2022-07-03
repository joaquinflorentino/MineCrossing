using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EraserButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Sprite eraserSprite;
    private bool isCursorOverEraser;

    // Start is called before the first frame update
    void Start()
    {
        eraserSprite = GetComponent<Image>().sprite;
    }

    public bool IsCursorOverEraser() {
        return isCursorOverEraser;
    }

    public void SelectEraser() {
        GameObject stampHolder = GameObject.Find("StampHolder");

        stampHolder.GetComponent<StampHolder>().SetIsStampButtonSelected(false);
        stampHolder.transform.GetChild(0).gameObject.SetActive(false);
        stampHolder.GetComponent<SpriteRenderer>().sprite = eraserSprite;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isCursorOverEraser = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isCursorOverEraser = false;
    }
}
