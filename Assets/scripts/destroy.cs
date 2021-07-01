using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class destroy : MonoBehaviour
{
    public Rigidbody rp;
    public Text txt, txt1;
    public GameObject YOUWON;
    int c = 0;
    private Vector3 begin, startpos;
    public GameObject thisplayer,GOP;
    // Start is called before the first frame update
    void Start()
    {
        // rp = GetComponent<Rigidbody>();
        begin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical"); //method bt2ra mn keyboard user bydos eh
        //Vector3 m = new Vector3(x, 0.0f, z);//de directions 0.0f no float
        //rp.AddForce(m * 100);
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < begin.y)
        {
            Vector3 v1 = new Vector3(0.0f, 100, 0.0f);
            rp.AddForce(v1 * 10);
        }
    }
    void OnTriggerEnter(Collider other)//other de btt8yar 3ady 
    {
        if (other.gameObject.CompareTag("coin"))
        {
            YOUWON.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (other.gameObject.CompareTag("gameover"))
        {
            /*       //Destroy(this.gameObject);
          transform.position = begin;
          rp.velocity = new Vector3(0, 0, 0);
          rp.angularVelocity = new Vector3(0, 0, 0);
          //txt1.text = "Game Over";
          */
            GAMEOVERSCRIPT A = new GAMEOVERSCRIPT(thisplayer , begin , GOP);
            A.viewepanel();
        }
        else if (other.gameObject.CompareTag("player"))
        {
            GAMEOVERSCRIPT A = new GAMEOVERSCRIPT(thisplayer, begin, GOP);
            A.viewepanel();
        }
        

    }
}
