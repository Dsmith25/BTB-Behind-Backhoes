using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    public void setDefaults()
    {
        int resolution = PlayerPrefs.GetInt("Resolution");
        int fullScreen = PlayerPrefs.GetInt("FullScreen");

        //bool fs = convert(fullScreen);
        //setFullScreen(fs);
        setResolution(resolution, fullScreen);

        string quality = PlayerPrefs.GetString("Quality");
        setSettings(quality);
        int shadows = PlayerPrefs.GetInt("Shadows");
        toggleShadows(shadows);
        //float fov = PlayerPrefs.GetFloat("FOV");
        //setFOV(fov);
        int AA = PlayerPrefs.GetInt("AA");
        setAA(AA);
        int vSync = PlayerPrefs.GetInt("VSync");
        setVsync(vSync);
        
    }

    public void setSettings(string quality)
    {
        switch (quality)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Medium":
                QualitySettings.SetQualityLevel(1);
                break;
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
        }
    }

    public void toggleShadows(int toggle)
    {
        Light[] lights = GameObject.FindObjectsOfType<Light>();
        foreach (Light l in lights)
        {
            if (toggle == 0)
            {
                l.shadows = LightShadows.None;
            }
            else if (toggle == 1)
            {
                l.shadows = LightShadows.Hard;
            }
            else if (toggle == 2)
            {
                l.shadows = LightShadows.Soft;
            }
        }
    }

    //public void setFOV(float angle)
    //{
    //    Camera.main.fieldOfView = angle;
    //}

    public void setAA(int samples)
    {
        if (samples == 0 || samples == 2 || samples == 4 || samples == 8)
        {
            QualitySettings.antiAliasing = samples;
        }
    }

    public void setVsync(int toggle)
    {
        QualitySettings.vSyncCount = toggle;
    }

    public void setResolution(int res, int fs) 
    {
        bool full = convert(fs);
        switch (res)
        {
            case 0:
                Screen.SetResolution(1920, 1080, full);
                break;
            case 1:
                Screen.SetResolution(1600,900, full);
                break;
            case 2:
                Screen.SetResolution(1280,1024, full);
                break;
            case 3:
                Screen.SetResolution(1280,800, full);
                break;
            case 4:
                Screen.SetResolution(640,400, full);
                break;
        }
    }

    bool convert(int toConvert)
    {
        if (toConvert == 0)
            return false;
        else
            return true;
    }

    public void setFullScreen(bool full)
    {
        Screen.fullScreen = full;
    }


}
