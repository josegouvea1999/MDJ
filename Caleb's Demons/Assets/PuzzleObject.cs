using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    private GameObject darkness_objects;
    private GameObject puzzle_ui;
    public GameObject leaf_object;
    public GameObject self_ui;
    private bool leaf_already_active = false;
    // Start is called before the first frame update
    void Start()
    {
        darkness_objects = GameObject.FindGameObjectWithTag("darkness");
        puzzle_ui = GameObject.FindGameObjectWithTag("puzzle-ui");
       // GameObject.FindGameObjectWithTag("leaf-slot").SetActive(false);
        

        if (gameObject.tag == "well-cover") {
            puzzle_ui.SetActive(false);
        }

        if (gameObject.GetComponent<Object.Object>().collectable) {
        //    self_ui = GameObject.FindGameObjectWithTag(gameObject.tag + "-ui");
            self_ui.SetActive(false);
            UnityEngine.Debug.Log("UI TAG " + gameObject.tag + "-ui");
        }

        if(gameObject.tag == "bucket-exit")
        {
            gameObject.SetActive(false);
        }

        if(gameObject.tag == "leaf")
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckFunctionality() {

        if (gameObject.tag == "well-cover")
        {
            UnityEngine.Debug.Log("READY TO CHECK WELL!");
            if (gameObject.GetComponent<Object.Object>().CheckDraggedThreslhold(new Vector2(0.7f, 0.7f)))
            {
                IlluminateRoom();
            }
        }

        else if (gameObject.tag == "tree" && !leaf_already_active)
        {
            leaf_object.SetActive(true);
            leaf_already_active = true;
        }

        else
        {
            EnableUI();
        }
    }

    public void EnableUI() {
        self_ui.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CheckMouseDown() {
  
        // set active correspnding ui!!
    }

    public void IlluminateRoom() {
        darkness_objects.SetActive(false);
        puzzle_ui.SetActive(true);
    }
}
