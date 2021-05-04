using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleSlot : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    private Puzzle puzzle;
    public RectTransform rectTransform;
    public Canvas canvas;
    public Vector3 scaled_size;
    public GameObject corresponding_object_ui;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = GameObject.FindGameObjectWithTag("puzzle-ui").GetComponent<Puzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObject(){
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        puzzle.ObjectAdded(gameObject.tag);
    }

    public void GetObject(PointerEventData pointerEventData)
    {
        corresponding_object_ui.SetActive(true);
        corresponding_object_ui.GetComponent<PuzzleObjectUI>().Stage(pointerEventData);
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        puzzle.ObjectRemoved(gameObject.tag);
    }

    public void OnPointerClick(PointerEventData pointerEventData) {
        /*if (gameObject.tag == "bucket-slot")
        {
            GetObject(pointerEventData);
        }*/
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        if (gameObject.tag == "bucket-slot")
        {
            GetObject(pointerEventData);
        }
    }
}
