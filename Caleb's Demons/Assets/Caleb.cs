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
    private bool climb_down = false;
    private float climb_distance = 0;
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
        else
        {
            switch (state)
            {
                case 1:
                    if ((isGrouned()))
                    {

                        Walk();
                    }
                    break;
                case 2:
                    Jump(_mov_Par.jump_sideForce);
                    state = 1;
                    break;
                case 3:
                    Climb(climb_down);
                    if (climb_distance == 0)
                    {
                        state = 1;
                    }

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
        curr_speed += 2*Time.fixedDeltaTime*Math.Sign(_mov_Par.max_speed);
        curr_speed = Mathf.Clamp(curr_speed, -_mov_Par.max_speed, _mov_Par.max_speed); // Clamps curSpeed

        _rigidbody.velocity = new Vector3(curr_speed, _rigidbody.velocity.y, 0);

    }

    public void State_change(float time, int s, int side_vel, int jump_force, bool down, float distance)
    {
        waiting = time;
        state = s;
        if (state == 1)
        {
            _mov_Par.max_speed = side_vel;
        }
        if (state == 2) {
            _mov_Par.jump_force = jump_force;
            _mov_Par.jump_sideForce = side_vel;
                }
        if (state == 3)
        {
            climb_down = down;
            climb_distance = distance;
        }
    }

    void Stop()
    {
        curr_speed -= 4 * Time.fixedDeltaTime*Math.Sign(curr_speed);
        curr_speed = Mathf.Clamp(Math.Abs(curr_speed), 0, _mov_Par.max_speed)*Math.Sign(curr_speed); // Clamps curSpeed

        _rigidbody.velocity = new Vector3(curr_speed, _rigidbody.velocity.y, 0);
    }

    private bool isGrouned()
    {
        float extrahieght = .01f;
        RaycastHit2D raycasthit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, extrahieght);
        /*Color raycolor;
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


    private void Climb(bool down)
    {
        if (!down)
        {
            _rigidbody.velocity = new Vector3(0, 3, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, -3, 0);

        }
        climb_distance -= 3 * Time.fixedDeltaTime;
        climb_distance = Mathf.Clamp(climb_distance, 0, 100); // Clamps distance
        if (climb_distance == 0)
        {
            _rigidbody.AddForce(new Vector3(1, 1, 0), ForceMode2D.Impulse);

        }

    }
}
