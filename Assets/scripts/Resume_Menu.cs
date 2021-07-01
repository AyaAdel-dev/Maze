using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Resume_Menu : MonoBehaviour
{
    public GameObject MenuInGame;
    bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeMenu();
            }
            else
            {
                PauseMenu();
            }
        }

    }
    private void PauseMenu()
    {
        MenuInGame.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeMenu()
    {
        Debug.Log("DAAAAAAAAAAAAAAAAAAAAAA");
        MenuInGame.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MAIN MENU");
    }

    public void Exittt()
    {
        Application.Quit();
    }
}
