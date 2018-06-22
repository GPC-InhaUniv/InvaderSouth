using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    public static string NextScene;

    private AccountInfo info;

    [SerializeField]
    private Image progressBar;
    [SerializeField]
    private Text progressText;
    [SerializeField]
    private Text pressAnyKeyText;
    [SerializeField]
    private GameObject controllerInfomationImage;

    private int percentage = 0;

    public static bool IsMainSceneLoading = false;

    public delegate void LoadInGameScene();

    public LoadInGameScene LoadInGameSceneDelegater;


    private void Awake()
    {

        Screen.SetResolution(700, 1080, true);
        info = GameObject.Find("AccountInfo").GetComponent<AccountInfo>();

        if (IsMainSceneLoading)
            controllerInfomationImage.SetActive(true);

        if (GameManager.Instance == null)
            GameManager.Instance.Awake();

        StartCoroutine(LoadScene());


    }



    public static void LoadScene(string sceneName)
    {
        if (sceneName == "Main")
            IsMainSceneLoading = true;
        else
            IsMainSceneLoading = false;

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
                if (progressBar.fillAmount == 1.0f) //가득 찼다면
                {
                    progressText.text = "100%";

                    yield return null;
                    if (NextScene.Equals("Main"))
                        LoadMainScene(asyncOperation);
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

    void LoadMainScene(AsyncOperation asyncOperation)
    {

        pressAnyKeyText.text = "Press Any Key To Start Game!";

        pressAnyKeyText.gameObject.SetActive(true);
        progressBar.gameObject.SetActive(false);
        if (Input.anyKeyDown)
        {
            LoadInGameSceneDelegater();
            asyncOperation.allowSceneActivation = true;
        }

    }

}
