using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public delegate void OpenOptionsMenu(bool hasOpened);
    public static OpenOptionsMenu onOpenOptionMenu;

    private bool inInterface = false;
    private bool inOptionsMenu = false;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject hUDUI;
    [SerializeField] private GameObject topMenuUI;
    [SerializeField] private GameObject settingUI;

    void Awake()
    {
        HexagonPuzzleManager.onHasEnteredInterface += InInterface;
        FirstLevelManager.onFadingInLevel += InInterface;
    }

    void Update()
    {
        if (!inInterface)
        {
            if(Input.GetKeyDown(KeyCode.Escape) && !inOptionsMenu)
            {
                OpenMenu();
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && inOptionsMenu)
            {
                CloseSettings();
                ResumeGame();
            }
        }
    }

    public void OpenMenu()
    {
        inOptionsMenu = true;
        onOpenOptionMenu(true);
        menuUI.gameObject.SetActive(true);
        hUDUI.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        inOptionsMenu = false;
        onOpenOptionMenu(false);
        menuUI.gameObject.SetActive(false);
        hUDUI.gameObject.SetActive(true);
    }

    public void OpenSettings()
    {
        settingUI.gameObject.SetActive(true);
        topMenuUI.gameObject.SetActive(false);
    }

    public void CloseSettings()
    {
        settingUI.gameObject.SetActive(false);
        topMenuUI.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void InInterface(bool hasEntered)
    {
        inInterface = hasEntered;
    }
}
