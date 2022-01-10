using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Control : MonoBehaviour
{
    public GameObject blue_finish, green_finish;

    public CanvasGroup canvasGroup;

    private void Start()
    {
        StartCoroutine(CoroutineFadeOut());
    }

    private void Update()
    {
        if (is_finish_all())
        {
            StartCoroutine(CoroutineFadeIn());
            Invoke("NextStage", 2f);
        }
    }

    public IEnumerator CoroutineFadeIn()
    {
        float time = 0;

        while (time < 1)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / 1);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    public IEnumerator CoroutineFadeOut()
    {
        float time = 0;

        while (time < 1)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, time / 1);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

    private bool is_finish_all()
    {
        bool b_finish = blue_finish.GetComponent<Blue_Finish>().is_finish();
        bool g_finish = green_finish.GetComponent<Green_Finish>().is_finish();

        if (b_finish & g_finish)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NextStage()
    {
        string scene_name = SceneManager.GetActiveScene().name;
        int scene_num = Int32.Parse(scene_name);

        SceneManager.LoadSceneAsync((scene_num + 1).ToString());
    }
}
