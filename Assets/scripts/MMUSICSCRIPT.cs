using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMUSICSCRIPT : MonoBehaviour
{
    public Slider slid;
    public AudioSource sauce;
    // Start is called before the first frame update
    void Start()
    {
        slid.value = sauce.volume = PlayerPrefs.GetFloat("slidervalue");
    }

    // Update is called once per frame
    void Update()
    {
        sauce.volume = slid.value;
        PlayerPrefs.SetFloat("slidervalue", slid.value);
        PlayerPrefs.SetFloat("musictime", sauce.time);
    }
  //  public void SubmitSliderSetting({ musicvol = slid.value;//Displays the value of the slider in the console. /*        Debug.Log(mainSlider.GetComponent<);*/}
///public void ChangeMusicVol(float newValue)
   // {
///musicvol = newValue;
   // }

}
