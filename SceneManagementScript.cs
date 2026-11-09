using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void MenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
