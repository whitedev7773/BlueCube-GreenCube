using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{

    public GameObject BlueCube, GreenCube;

    public bool enable;

    public float speed;

    public float fly;

    public void tracking_bluecube()
    {
        float x = BlueCube.transform.position.x;
        float y = BlueCube.transform.position.y;
        float z = BlueCube.transform.position.z;
        Vector3 target = new Vector3(x, y + fly, z);
        transform.position = Vector3.Lerp(transform.position, target, speed / 100);
    }

    public void tracking_greencube()
    {
        float x = GreenCube.transform.position.x;
        float y = GreenCube.transform.position.y;
        float z = GreenCube.transform.position.z;
        Vector3 target = new Vector3(x, y + fly, z);
        transform.position = Vector3.Lerp(transform.position, target, speed / 100);
    }

    void Update()
    {
        if (enable == false)
        {
            return;
        }

        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        if ((Input.GetKey(KeyCode.UpArrow) || wheelInput > 0) && fly < 100)    // 위 화살표 키를 누르거나 마우스 휠을 위로 올리면 카메라 Y를 위로
        {
            fly += 0.1f + wheelInput * 8;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || wheelInput < 0) && fly > 3)  // 아래 화살표 키를 누르거나 마우스 휠을 아래로 올리면 카메라 Y를 아래로
        {
            fly -= 0.1f - wheelInput * 8;
        }

        if (BlueCube.GetComponent<Cube_Move>().enable)
        {
            tracking_bluecube();
        }
        else
        {
            tracking_greencube();
        }
    }
}
