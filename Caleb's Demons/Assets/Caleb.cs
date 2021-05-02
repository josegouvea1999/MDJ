using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
struct Caleb_Movment_Par
{
    [Header("Caleb's Movement")]

    public int jump_force;
    public int max_speed;
    public int jump_sideForce;
    public LayerMask floor;

}

public class Caleb : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider2D;
    // Mal feito mas 0 - Parado 1 - Walk 2- Jump
    private int state = 1;
    private float curr_speed;
    private bool grounded_flag = false;
    private float waiting = 0;

    [SerializeField]

    private Caleb_Movment_Par _mov_Par;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (waiting > 0)
        {
            waiting -= Time.fixedDeltaTime;
            Stop();
        }
        else if(isGrouned())
        {
            switch (state)
            {
                case 1:
                    Walk();
                    break;
                case 2:
                    Jump(_mov_Par.jump_sideForce);
                    state = 1;
                    break;
                default:
                    break;
            }
        }


    }


    void Jump(int jump_side_force)
    {
        _rigidbody.AddForce(new Vector3(jump_side_force, _mov_Par.jump_force, 0), ForceMode2D.Impulse);

    }
    void Walk()
    {
        curr_speed += Time.fixedDeltaTime;
        curr_speed = Mathf.Clamp(curr_speed, -_mov_Par.max_speed, _mov_Par.max_speed); // Clamps curSpeed

        _rigidbody.velocity = new Vector3(curr_speed, _rigidbody.velocity.y, 0);

    }

    public void State_change(float time, int s)
    {
        waiting = time;
        state = s;
    }

    void Stop()
    {
        curr_speed -= 4 * Time.fixedDeltaTime;
        curr_speed = Mathf.Clamp(curr_speed, 0, _mov_Par.max_speed); // Clamps curSpeed

        _rigidbody.velocity = new Vector3(curr_speed, _rigidbody.velocity.y, 0);
    }

    private bool isGrouned()
    {
        float extrahieght = .1f;
        RaycastHit2D raycasthit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, extrahieght/*,_mov_Par.floor*/);
       /* Color raycolor;
        if(raycasthit.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }

        Debug.DrawRay(_boxCollider2D.bounds.center + new Vector3(_boxCollider2D.bounds.extents.x,0),Vector2.down * (_boxCollider2D.bounds.extents.y+extrahieght),raycolor);
        Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, 0), Vector2.down * (_boxCollider2D.bounds.extents.y + extrahieght), raycolor);
        Debug.DrawRay(_boxCollider2D.bounds.center - new Vector3(_boxCollider2D.bounds.extents.x, _boxCollider2D.bounds.extents.y), Vector2.right * (_boxCollider2D.bounds.extents.x + extrahieght), raycolor);
        Debug.Log(raycasthit.collider);*/
        return raycasthit.collider != null;
    }
}
