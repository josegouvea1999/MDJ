using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject collected;
    public int ui_index;
    public Inventory_UI inventory_ui;
    public RectTransform rectTransform;
    public Canvas canvas;
    public Vector3 regular_size;
    public Vector3 scaled_size;
    public Vector3 initial_position;
    public bool combinable;
    public string pair_tag = null;
    public bool dragging = false;
    public Sprite result_sprite = null;
    public string result_tag = null;
    public bool combined = false;
    public bool just_combined = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
        inventory_ui = GameObject.FindGameObjectWithTag("inventory-ui").GetComponent<Inventory_UI>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
        regular_size = rectTransform.localScale;
        scaled_size = new Vector3(rectTransform.localScale.x * 2f, rectTransform.localScale.y * 2f, rectTransform.localScale.z);
        initial_position = rectTransform.localPosition;
        combinable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddObject(GameObject _collected) {
        collected = _collected;
        if (collected.GetComponent<Combinable>())
        {
            combinable = true;
            pair_tag = collected.GetComponent<Combinable>().GetPairTag();
            result_sprite = collected.GetComponent<Combinable>().GetResultSprite();
            result_tag = collected.GetComponent<Combinable>().GetResultTag();
        }
        gameObject.GetComponent<Image>().sprite = _collected.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void ClearObject() {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Image>().enabled = false;
        inventory_ui.RemoveObject(collected);
        collected = null;
    }

    public void SetUIIndex(int index) {
        ui_index = index;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("DRAGGING");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        rectTransform.localScale = scaled_size;
        dragging = true;
    }

    public void OnEndDrag(PointerEventData eventData) {
        UnityEngine.Debug.Log("STOP DRAGGING ");
        if (!just_combined) {
            collected.GetComponent<Object.Object>().Stage();
        }
        if (just_combined)
        {
            just_combined = false;
        }
       
        rectTransform.localPosition = initial_position;
        gameObject.GetComponent<Image>().enabled = false;
        dragging = false;
    }

    void CombineObjects(GameObject other) {
        if (other.GetComponent<Slot>().GetPairTag() == collected.tag) {
            UnityEngine.Debug.Log("COMBINEEEE");            
            DisablePair(other);
            ChangeToCombination();
        }
    }

    public void ChangeToCombination() {
        UnityEngine.Debug.Log("ChangeToCombination");
        gameObject.GetComponent<Image>().sprite = result_sprite;
        collected = collected.GetComponent<Combinable>().result_object;
        UnityEngine.Debug.Log(collected);
        if (collected.GetComponent<Combinable>())
        {
            UnityEngine.Debug.Log("Has combinatino");
            combinable = true;
            pair_tag = collected.GetComponent<Combinable>().GetPairTag();
            result_sprite = collected.GetComponent<Combinable>().GetResultSprite();
            result_tag = collected.GetComponent<Combinable>().GetResultTag();
        }
        else {
            UnityEngine.Debug.Log("Has no combinatino");
            combinable = false;
            pair_tag = null;
            result_sprite = null;
            result_tag = null;
        }
        
    }

    public void DisablePair(GameObject other)
    {
        UnityEngine.Debug.Log("DisablePair");
        other.GetComponent<Image>().sprite = null;
        other.GetComponent<Image>().enabled = false;
        other.GetComponent<Slot>().GoToInitialPosition();
        other.GetComponent<Slot>().just_combined = true;
    }

    public void GoToInitialPosition() {
        gameObject.transform.position = initial_position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Triggered");
        if (!dragging)
        {
            CombineObjects(other.gameObject);
            combined = true;
            other.GetComponent<Slot>().combined = true;
        }
    }

    public string GetPairTag() {
        return pair_tag;
    }

}
