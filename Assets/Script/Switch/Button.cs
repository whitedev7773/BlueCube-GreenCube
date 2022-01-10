using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool enable;
    public bool toggle_mode;
    public GameObject Door, PushSound, PullSound;

    private float button_x, button_y, button_z;

    private void OnTriggerEnter(Collider other)
    {
        if (toggle_mode)
        {
            enable = !enable;
            if (enable){ PlayPushSound(); }
            else { PlayPullSound(); }
            Door.GetComponent<Door>().open = !Door.GetComponent<Door>().open;
        }
        else
        {
            PlayPushSound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toggle_mode) { return; }
        else
        {
            enable = true;
        }
        Door.GetComponent<Door>().open = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (toggle_mode) { return; }
        else
        {
            enable = false;
            PlayPullSound();
            Door.GetComponent<Door>().open = false;
        }
    }

    public void press_down()
    {
        Vector3 target = new Vector3(button_x, button_y - 0.15f, button_z);
        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }

    public void pull_up()
    {
        Vector3 target = new Vector3(button_x, button_y, button_z);
        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }

    public void PlayPushSound()
    {
        float Pitch = Random.Range(1.0f, 3.0f);
        PushSound.GetComponent<AudioSource>().pitch = Pitch;
        PushSound.GetComponent<AudioSource>().Play();
    }

    public void PlayPullSound()
    {
        float Pitch = Random.Range(1.0f, 3.0f);
        PullSound.GetComponent<AudioSource>().pitch = Pitch;
        PullSound.GetComponent<AudioSource>().Play();
    }

    private void Start()
    {
        button_x = transform.position.x;
        button_y = transform.position.y;
        button_z = transform.position.z;
    }

    private void Update()
    {
        if (enable){ press_down(); }
        else { pull_up(); }
    }
}
