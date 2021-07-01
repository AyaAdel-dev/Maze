using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GAMEOVERSCRIPT : MonoBehaviour
{
    public GameObject PLAYER;
    public GameObject GAMEOVERPANEL;
    private Vector3 beginPOS;
    float counter ,counterinitial;
    public Text TIMELEFT;
    public GAMEOVERSCRIPT(GameObject player, Vector3 begin22, GameObject gameoverpanel)
    {
        this.PLAYER = player;
        this.beginPOS = begin22;
        this.GAMEOVERPANEL = gameoverpanel;
    }
    private void Start()
    {
        counter = 4000.0f;
        counterinitial = counter;
        disablepanel();
        beginPOS = PLAYER.transform.position;
     /*   TPLAYER = PLAYER;
        TbeginPOS = beginPOS;
        TGAMEOVERPANEL = GAMEOVERPANEL;*/
    }
    /* private void Awake()
     {
         this.PLAYER = TPLAYER;
         this.beginPOS = TbeginPOS;
         this.GAMEOVERPANEL = TGAMEOVERPANEL;
         *//*viewepanel();*//*
     }*/
    public void mainmenuloader()
    {
        disablepanel();
        SceneManager.LoadScene("MAIN MENU");
    }
    private void Update()
    {
        counter -= Time.deltaTime;
        if (counter < 1.0f)
        {
              TIMELEFT.text = "";
              viewepanel();
           // TIMELEFT.text = "TIME LEFT : " + counter;
        }
        else
        {
            TIMELEFT.text = "TIME LEFT : " + (int) counter;
        }
    }
    public void TryAgain()
    {
        PLAYER.transform.position = beginPOS;
        disablepanel();
        PLAYER.SetActive(true);
        Cursor.visible = false;
        counter = counterinitial;
    }

    private void disablepanel()
    {
        GAMEOVERPANEL.SetActive(false);
    }

    public void viewepanel()
    {
        GAMEOVERPANEL.SetActive(true);
        PLAYER.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
}