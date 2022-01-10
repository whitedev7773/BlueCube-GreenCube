using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Wall : MonoBehaviour
{
    public List<GameObject> target_points = new List<GameObject>();
    public GameObject Wall;
    public float move_speed;
    public float delay; // 한 번 움직임당 딜레이
    private int turn; // 0 : 기존 위치
                     // 1 : 타겟 포인트 1
                     // 2 : 타겟 포인트 2
                     // n : 타겟 포인트 n

    /*
     * Vector3 target = new Vector3(target_x, target_y, target_z);
     * Wall.transform.position = Vector3.MoveTowards(Wall.transform.position, target, (move_speed / 100));
    */

    private float exist_x, exist_y, exist_z;
    private float target_x, target_y, target_z;

    private void StartMoveInOrder()
    {
        UpdatePosition();
        Vector3 target = new Vector3(target_x, target_y, target_z);
        Wall.transform.position = Vector3.MoveTowards(Wall.transform.position, target, (move_speed / 1000));
        if (exist_x == target_x &&
            exist_y == target_y &&
            exist_z == target_z)
        {
            turn += 1;
            if (turn >= target_points.Count)
            {
                turn = 0;
            }
            Invoke("StartMoveInOrder", delay);
        }
        else
        {
            UpdatePosition();
            Invoke("StartMoveInOrder", 0);
        }
    }

    private void UpdatePosition()
    {
        exist_x = Wall.transform.position.x;
        exist_y = Wall.transform.position.y;
        exist_z = Wall.transform.position.z;

        target_x = target_points[turn].transform.position.x;
        target_y = target_points[turn].transform.position.y;
        target_z = target_points[turn].transform.position.z;
    }

    private void Start()
    {
        StartMoveInOrder();
    }

    private void Update()
    {
        
    }
}
