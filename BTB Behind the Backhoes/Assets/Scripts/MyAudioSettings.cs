using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioSettings : MonoBehaviour
{
    public AudioSource bgVolume;
    public List<AudioSource> sfxVolume;

    public void defaultSettings()
    {
        bgVolume.volume = PlayerPrefs.GetFloat("BGVol");
        foreach (AudioSource source in sfxVolume)
        {
            source.volume = PlayerPrefs.GetFloat("SFXVol");
        }

    }

    public void setAudioType(string speakerMode)
    {
        switch (speakerMode)
        {
            case "Mono":
                AudioSettings.speakerMode = AudioSpeakerMode.Mono;
                break;
            case "Stereo":
                AudioSettings.speakerMode = AudioSpeakerMode.Stereo;
                break;
        }
    }

    public void setVolume(float vol)
    {
        GetComponent<BG_Music_Manager>().bgVolume = vol;
    }
}
