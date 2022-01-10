using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Finish : MonoBehaviour
{
    private bool finish;

    public bool is_finish()
    {
        return finish;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BlueCube")
        {
            finish = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BlueCube")
        {
            finish = false;
        }
    }
}
