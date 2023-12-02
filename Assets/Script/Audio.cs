using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject MasterSlider, MusicSlider, SfxSlider;
    public AudioMixer mixer;
    private Slider _masterSlider, _musicSlider, _sfxSlider;
    public Text MasterVolumeLabel, MusicVolumeLabel, SfxVolumeLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        if(MasterSlider != null)
        {
            _masterSlider = MasterSlider.GetComponent<Slider>();
            UpdateValueOnChange(_masterSlider.value, "Master", MasterVolumeLabel);
            _masterSlider.onValueChanged.AddListener(delegate
            {
                UpdateValueOnChange(_masterSlider.value, "Master", MasterVolumeLabel);
            });
        }
        if(MusicSlider != null)
        {
            _musicSlider = MusicSlider.GetComponent<Slider>();
            UpdateValueOnChange(_musicSlider.value, "Music", MusicVolumeLabel);
            _musicSlider.onValueChanged.AddListener(delegate
            {
                UpdateValueOnChange(_musicSlider.value, "Music", MusicVolumeLabel);
            });
        }
        if(SfxSlider != null)
        {
            _sfxSlider = SfxSlider.GetComponent<Slider>();
            UpdateValueOnChange(_sfxSlider.value, "Sfx", SfxVolumeLabel);
            _sfxSlider.onValueChanged.AddListener(delegate
            {
                UpdateValueOnChange(_sfxSlider.value, "Sfx", SfxVolumeLabel);
            });
        }

        
    }
    public void UpdateValueOnChange(float value, string volumeName, Text volumeLabel)
    {
        if(mixer != null)
        {
            mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);
        }
        if(volumeLabel != null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }
    }
}
