using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PuzzleObjectUI : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform rectTransform;
    private GameObject puzzle_ui;
    public Canvas canvas;
    public string object_puzzle_slot;
    public string final_object_tag = null;
    public GameObject final_object;
    public string final_object_ui_tag = null;
    public GameObject final_object_ui;
    private string object_tag;
    private bool already_in_puzzle = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        puzzle_ui = GameObject.FindGameObjectWithTag("puzzle-ui");
        canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
        int pos = gameObject.tag.IndexOf("-ui");
        string beforeFounder = gameObject.tag.Remove(pos);
        object_tag = beforeFounder;
        object_puzzle_slot = object_tag + "-slot";
        final_object_tag = final_object.tag;
        final_object_ui_tag = final_object_ui.tag;
        final_object_ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("DRAGGING");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("STOP DRAGGING ");
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Triggered");
        UnityEngine.Debug.Log("EU: " + gameObject.tag);
        UnityEngine.Debug.Log("OUTRO: " + other.tag);
        UnityEngine.Debug.Log("OPBJEC PUZZLE: " + object_puzzle_slot);

        if (other.tag == object_puzzle_slot){
            UnityEngine.Debug.Log("ENCONTREI SLOT!!");
            other.GetComponent<PuzzleSlot>().SetObject();
            already_in_puzzle = true;
            gameObject.SetActive(false);
        }

        if (final_object_ui != null && other.tag == final_object_ui_tag && already_in_puzzle) {
            //  GameObject.FindGameObjectWithTag(final_object_tag).GetComponent<SpriteRenderer>().enabled = true;    
            final_object_ui.SetActive(false);          
            final_object.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Stage(PointerEventData pointerEventData) {
        rectTransform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;
        if (final_object_ui_tag != null)
        {
            UnityEngine.Debug.Log(final_object_ui_tag);
            final_object_ui.SetActive(true);
        }
    }
}
