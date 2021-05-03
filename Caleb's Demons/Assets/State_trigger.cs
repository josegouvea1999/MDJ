using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_trigger : MonoBehaviour
{
    Collider2D _collider;
    public int wait = 1;
    public int state = 2;
    public int side_vel = 5;

    //if state is 2
    public int jump_force = 4;


    //if state is 3 (climb)
    public bool down = false;
    public int climb_distance = 10;


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
            caleb.State_change(wait, state, side_vel, jump_force, down, climb_distance);
        }
    }
}