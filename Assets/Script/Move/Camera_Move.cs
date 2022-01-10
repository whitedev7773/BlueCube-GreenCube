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

        if ((Input.GetKey(KeyCode.UpArrow) || wheelInput > 0) && fly < 100)    // �� ȭ��ǥ Ű�� �����ų� ���콺 ���� ���� �ø��� ī�޶� Y�� ����
        {
            fly += 0.1f + wheelInput * 8;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || wheelInput < 0) && fly > 3)  // �Ʒ� ȭ��ǥ Ű�� �����ų� ���콺 ���� �Ʒ��� �ø��� ī�޶� Y�� �Ʒ���
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
