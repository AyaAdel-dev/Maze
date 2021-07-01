using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{   
    public void loadlevel1()
    {
        SceneManager.LoadScene("scene1");
    }
    public void loadlevel2()
    {
        SceneManager.LoadScene("scene2");
    }
    public void loadlevel3()
    {
        SceneManager.LoadScene("scene3");
    }
    public void EndGame()
    {
        Application.Quit();
    }

}
