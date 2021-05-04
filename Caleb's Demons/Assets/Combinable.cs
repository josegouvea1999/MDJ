using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object;

public class Combinable : Object.Object
{
    public GameObject pair_object;
    public GameObject result_object;
    protected string pair_tag;
    protected string result_tag;
    // Start is called before the first frame update
    void Start()
    {
        if (pair_object != null) {
            UnityEngine.Debug.Log("my tag: " + gameObject.tag + " pair tag: " + pair_object.tag);
            pair_tag = pair_object.tag;
        }

        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        initial_z = gameObject.transform.position.z;
        dragging = false;

        if (result_object)
        {
            result_object.SetActive(false);
            result_tag = result_object.tag;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public string GetPairTag()
    {
        return pair_tag;
    }

    public string GetResultTag()
    {
        return result_tag;
    }

    public Sprite GetResultSprite() {
        return result_object.GetComponent<SpriteRenderer>().sprite;
    }
}
