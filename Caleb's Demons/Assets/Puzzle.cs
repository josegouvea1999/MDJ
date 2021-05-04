using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    private int current_in_slot = 0;
    private int max_in_slot = 4;
    private GameObject button;
    public GameObject bucket_exit_object;
    public bool Caleb_in = false;
    private bool can_move_bucket = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("button-puzzle");
        button.GetComponent<Button>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_move_bucket && bucket_exit_object.transform.position.y <=3)
        {   
            bucket_exit_object.transform.position = new Vector3(bucket_exit_object.transform.position.x, bucket_exit_object.transform.position.y + 0.02f, bucket_exit_object.transform.position.z);
        }
    }

    public void ObjectAdded(string tag) {
        current_in_slot++;
        if (current_in_slot == max_in_slot) {
            UnityEngine.Debug.Log("FREE CALEB!");
            button.GetComponent<Button>().enabled = true;
            button.GetComponent<Image>().color = new Color(button.GetComponent<Image>().color.r, button.GetComponent<Image>().color.g, button.GetComponent<Image>().color.b, 255); ;
        }
    }

    public void ObjectRemoved(string tag)
    {
        current_in_slot--;
        if (current_in_slot == 0)
        {
            UnityEngine.Debug.Log("PUZZLE INCOMPLETE!");
        }
    }
    public void EnableFreedom() {
        UnityEngine.Debug.Log("GO CALEB!!");
        if (bucket_exit_object.activeSelf && Caleb_in)
        {
            MoveBucket();
        }
    }

    public void MoveBucket() {
        can_move_bucket = true;
    }
}
