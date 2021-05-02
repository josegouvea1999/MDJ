using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    private GameObject collected;
    private int ui_index;
    private Inventory_UI inventory_ui;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
        inventory_ui = GameObject.FindGameObjectWithTag("inventory-ui").GetComponent<Inventory_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(GameObject _collected) {
        collected = _collected;
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

    public void DisableImage() { 
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        collected.SetActive(true);
        ClearObject();
    }

}
