using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSaving : MonoBehaviour
{
    public Slider soundSlider;
    public Slider sfxSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("Sound", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 1);
    }

    // Update is called once per frame
    public void SaveChange()
    {
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
    }
}
