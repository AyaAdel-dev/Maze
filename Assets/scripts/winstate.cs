using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winstate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }
    
    // Update is called once per frame
    public void levell22()
    {
        SceneManager.LoadScene("scene2");
    }
    public void level3()
    {
        SceneManager.LoadScene("scene3");
    }
    public void MAINMENU()
    {
        SceneManager.LoadScene("MAIN MENU");
    }
}
