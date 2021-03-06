﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    public static string NextScene;

    [SerializeField]
    Image progressBar;
    [SerializeField]
    Text progressText;
    [SerializeField]
    Text pressAnyKeyText;
    int percentage = 0;



    private void Awake()
    {

        Screen.SetResolution(700, 1080, true);

        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        NextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(NextScene);
        asyncOperation.allowSceneActivation = false;

        float timer = 0.0f;
        while (!asyncOperation.isDone)  //종료되기 전까지 while문 실행
        {
            yield return null;
            timer += Time.deltaTime;

            if (asyncOperation.progress >= 0.9f)
            {

                progressBar.fillAmount += timer / 6f;  //프로그레스 바 채우기
                percentage = Convert.ToInt32(progressBar.fillAmount * 100);
                progressText.text = percentage.ToString() + "%";
                //    Debug.Log(" progressBar.fillAmount =" + progressBar.fillAmount);
                if (progressBar.fillAmount == 1.0f) //가득 찼다면
                {
                    progressText.text = "100%";
                    
                    yield return null;
                    if (NextScene.Equals("Main"))
                    {
                        pressAnyKeyText.gameObject.SetActive(true);
                        if(Input.anyKeyDown)
                        asyncOperation.allowSceneActivation = true;
                    }
                    else
                        asyncOperation.allowSceneActivation = true;
                }

                else
                {
                    progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, asyncOperation.progress, timer);

                    if (progressBar.fillAmount > asyncOperation.progress)
                    {
                        timer = 0.0f;
                    }
                }
            }
        }
    }

}
