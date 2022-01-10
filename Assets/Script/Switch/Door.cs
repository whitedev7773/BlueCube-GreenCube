using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool open;

    private float door_x, door_y, door_z;

    public void Open()
    {
        Vector3 target = new Vector3(door_x, door_y - 1, door_z);
        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }

    public void Close()
    {
        Vector3 target = new Vector3(door_x, door_y, door_z);
        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }

    private void Start()
    {
        door_x = transform.position.x;
        door_y = transform.position.y;
        door_z = transform.position.z;
    }

    private void Update()
    {
        if (open) { Open(); }
        else { Close(); }
    }
}
