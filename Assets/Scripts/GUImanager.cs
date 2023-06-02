using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GUImanager : MonoBehaviour
{
    public void Play()
    {
      SceneManager.LoadScene("Level");
    }
    public void Exit()
    {
      Application.Quit();
    }
    public void OnMenu()
    {
      SceneManager.LoadScene(0);
    }

    public void Setting()
    {
      SceneManager.LoadScene("Setting");
    }
}
