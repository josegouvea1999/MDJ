using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_trigger : MonoBehaviour
{
    Collider2D _collider;
    public int wait = 1;
    public int state = 2;
    public bool down = false;
    public float distance = 10;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            Caleb caleb = collision.gameObject.GetComponent<Caleb>();
            caleb.State_change(wait, state,down,distance);
        }
    }
}
