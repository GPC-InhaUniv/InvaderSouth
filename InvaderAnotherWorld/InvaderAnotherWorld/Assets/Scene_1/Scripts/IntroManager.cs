using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private Image IntroPanelImage;
    [SerializeField]
    private GameObject LoginManager;

    private bool isLoadedIntro;
    private void Start()
    {
        Screen.SetResolution(700, 1080, true);
        isLoadedIntro = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (IntroPanelImage.color.a >= 0.99 && !isLoadedIntro)
        {
            isLoadedIntro = true;
            StartCoroutine(ChangePanelIntroToLogin());
        }

    }

    IEnumerator ChangePanelIntroToLogin()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        LoginManager.SetActive(true);

    }
}
