using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject stonePathStamp;

    private SpriteRenderer spriteRenderer;
    private float moveSpeed = 3f;
    private int index = 0;
    private List<GameObject> stampsObtained = new List<GameObject>();
    private bool isStampButtonSelected = true;
    private int stampSortOrder = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AddStamp(new List<GameObject>() {stonePathStamp});
        SwitchStamp();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();

        if (isStampButtonSelected) {
            if (Input.GetMouseButtonDown(0) && !GameObject.Find("EraserButton").GetComponent<EraserButton>().IsCursorOverEraser()) {
                GameObject stamp = Instantiate(transform.GetChild(0).gameObject, transform.position, Quaternion.identity);
                IncramentStampSortOrder(stamp);
                GameObject.Find("ClearButton").GetComponent<ClearButton>().UpdateActiveStampsInScene(stamp);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                if (index < stampsObtained.Count-1) {
                    index++;
                }
                SwitchStamp();
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (index > 0) {
                    index--;
                }
                SwitchStamp();
            }
        }
    }

    public void AddStamp(List<GameObject> stamp) {
        stampsObtained.AddRange(stamp);
    }

    public bool IsStampButtonSelected() {
        return isStampButtonSelected;
    }

    public void SetIsStampButtonSelected(bool value) {
        isStampButtonSelected = value;
    }

    public int GetStampSortOrder() {
        return stampSortOrder;
    }

    private void SwitchStamp() {
        if (transform.childCount > 0) {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).parent = null;
        }
        GameObject newStamp = stampsObtained[index];
        newStamp.SetActive(true);
        newStamp.transform.position = gameObject.transform.position;
        newStamp.transform.SetParent(gameObject.transform);

        spriteRenderer.sprite = newStamp.GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("SelectedStampText").GetComponent<SelectedStampText>().UpdateText(newStamp.GetComponent<Stamp>().GetStampName());
    }

    private void FollowMouse() {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
    }

    private void IncramentStampSortOrder(GameObject stamp) {
        stampSortOrder++;
        stamp.GetComponent<SpriteRenderer>().sortingOrder = stampSortOrder;
        spriteRenderer.sortingOrder = stampSortOrder + 1;
    }
}
