using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYMUSIC : MonoBehaviour
{
    public AudioSource sauce;
    // Start is called before the first frame update
    void Start()
    {
        sauce.time = PlayerPrefs.GetFloat("musictime");
        sauce.volume = PlayerPrefs.GetFloat("slidervalue");
    }
}
