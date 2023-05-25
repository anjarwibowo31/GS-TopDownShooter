using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private GameObject[] muteToggle;
    [SerializeField] private Slider sliderBGM;

    private void Start()
    {
        sliderBGM.value = AudioManager.Instance.GetVolumeValue();
    }

    private void Update()
    {
        if (AudioManager.Instance.IsMute == true)
        {
            muteToggle[0].SetActive(false);
            muteToggle[1].SetActive(true);
        }
        else
        {
            muteToggle[0].SetActive(true);
            muteToggle[1].SetActive(false);
        }

    }

    public void OnVolumeChanged()
    {
        AudioManager.Instance.OnVolumeChange(sliderBGM.value);
    }

    public void OnMuteToggle()
    {
        AudioManager.Instance.OnMuteToogle();
    }
}
