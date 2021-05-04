using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            Camera.main.GetComponent<MainCamera>().right=true;
            Debug.Log("next Screen");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
