using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("VolumParam", Mathf.Log10(sliderValue) * 20);
    }
}
