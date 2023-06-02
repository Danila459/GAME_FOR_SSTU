using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenuScript : MonoBehaviour
{

    public GameObject settingsPanel;
    public void Play()
    {
      SceneManager.LoadScene(1);
    }
    public void Exit()
    {
      Application.Quit();
    }
    public void OnMenu()
    {
      SceneManager.LoadScene(0);
    }

    //Переходим в настройки
    public void SettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    //Выход из настроек
    public void ExitSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = true;
    }


    public void SetWindowed()
    {
        Screen.fullScreen = false;
    }
}
