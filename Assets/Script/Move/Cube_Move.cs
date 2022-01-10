using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Move : MonoBehaviour
{

    public float speed;
    public bool enable;

    public void Move_Up()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime / 6);
    }

    public void Move_Down()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime / 6);
    }

    public void Move_Left()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime / 6);
    }

    public void Move_Right()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime / 6);
    }

    public void toggle_move()
    {
        enable = !enable;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggle_move();
        }

        if (enable == false) return;

        if (Input.GetKey(KeyCode.W))
        {
            Move_Up();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move_Down();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move_Left();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move_Right();
        }
    }
}
