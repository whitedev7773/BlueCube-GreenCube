using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Finish : MonoBehaviour
{
    private bool finish;

    public bool is_finish()
    {
        return finish;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "GreenCube")
        {
            finish = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GreenCube")
        {
            finish = false;

        }
    }
}