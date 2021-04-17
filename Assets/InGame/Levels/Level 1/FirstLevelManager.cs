using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirstLevelManager : MonoBehaviour
{
    public delegate void FadingInLevel(bool fadingIn);
    public static FadingInLevel onFadingInLevel;

    [Header("Fade Time")]
    [SerializeField] float loadingScreenTime = 10f;
    [SerializeField] float waitTime = 3f;
    
    [Header("UI")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private TMPro.TMP_Text loadingText;
    [SerializeField] private GameObject fadeContainer;
    [SerializeField] private Animator fadePanel;
    [SerializeField] private Animator fadeText;

    private void Awake()
    {
        loadingScreen.gameObject.SetActive(true);
        onFadingInLevel(true);
        StartCoroutine("LoadAndFadeIn");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        fadePanel = fadePanel.GetComponent<Animator>();
        fadeText = fadeText.GetComponent<Animator>();
    }

    IEnumerator LoadAndFadeIn()
    {
        yield return new WaitForSeconds(loadingScreenTime);

            loadingScreen.gameObject.SetActive(false);
            fadeContainer.gameObject.SetActive(true);

            fadePanel.Play("PanelFadeOutAnimation");
            fadeText.Play("TextFadeInAnimation");

        yield return new WaitForSeconds(waitTime);

            onFadingInLevel(false);
            fadeText.Play("TextFadeOutAnimation");

        yield return new WaitForSeconds(3);

            fadeContainer.gameObject.SetActive(false);
    }
}
