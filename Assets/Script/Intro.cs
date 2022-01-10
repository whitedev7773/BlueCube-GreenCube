using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private void Start()
    {
        StartCoroutine(CoroutineFadeOut());
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

    public void OnClickButton()
    {
        StartCoroutine(CoroutineFadeIn());
        Invoke("StartGame", 2);
    }

    private void DebugMap()
    {
        SceneManager.LoadSceneAsync("Debug Map");
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("1");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine(CoroutineFadeIn());
            Invoke("DebugMap", 2);
        }
    }
}
