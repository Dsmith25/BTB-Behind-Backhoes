using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    

public class My_GUI : MonoBehaviour
{
    public VideoSettings videosetting;
    public MyAudioSettings audiosettings;
    public AudioSource musicPlayer;
    public Rect optionsRect = new Rect(0,0,500,500);
    int full_para = 0;
    bool full_bool = true;
    public bool GUIopen = false;
    float fov = 90f;
    float bgVol = .5f;
    float sfxVol =  .5f;
    bool vsync_bool = false;
   //
    public List<AudioSource> soundEffects;
    int resolution;
    string quality;
    int shadows;
    int AA;
    int vSync;

    private void Awake()
    {
    }



    // Use this for initialization
    void Start ()
    {
        videosetting.setDefaults();
        audiosettings.defaultSettings();
        Cursor.visible = false; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Time.timeScale == 1)
            {

                if (GUIopen == false)
                {
                    Time.timeScale = 0;
                    GUIopen = !GUIopen;
                    Cursor.visible = true;
                }
                else
                {
                    Time.timeScale = 1;
                    GUIopen = !GUIopen;
                    Cursor.visible = false;
                }
                     
            }
         }
	}
    public void OnGUI()
    {
        if(GUIopen)
            optionsRect = GUI.Window(0, optionsRect, OptionsGUI, "Options");

    }

    public void OptionsGUI(int gui)
    {
        GUILayout.BeginArea(new Rect(0, 50, 800, 800));

        GUI.Label(new Rect(25, 0, 100, 30), "Resolution:");

        if (GUI.Button(new Rect(25, 20, 75, 20), "1920x1080"))
        {
            videosetting.setResolution(0, full_para);
            resolution = 0;
        }
        if (GUI.Button(new Rect(100, 20, 75, 20), "1600x900"))
        {
            videosetting.setResolution(1, full_para);
            resolution = 1;
        }
        if (GUI.Button(new Rect(175, 20, 75, 20), "1280x1024"))
        {
            videosetting.setResolution(2, full_para);
            resolution = 2;
        }
        if (GUI.Button(new Rect(250, 20, 75, 20), "1280x800"))
        {
            videosetting.setResolution(3, full_para);
            resolution = 3;
        }
        if (GUI.Button(new Rect(325, 20, 75, 20), "640x400"))
        {
            videosetting.setResolution(4, full_para);
            resolution = 4;

        }
        PlayerPrefs.SetInt("Resolution", resolution);

        GUI.Label(new Rect(25, 50, 100, 30), "Quality:");
        if (GUI.Button(new Rect(25, 70, 75, 20), "Low"))
        {
            videosetting.setSettings("Low");
            quality = "Low";
        }
        if (GUI.Button(new Rect(100, 70, 75, 20), "Medium"))
        {
            videosetting.setSettings("Medium");
            quality = "Medium";
        }
        if (GUI.Button(new Rect(175, 70, 75, 20), "High"))
        {
            videosetting.setSettings("High");
            quality = "High";
        }
        PlayerPrefs.SetString("Qaulity", quality);

        //GUI.Label(new Rect(25, 100, 100, 30), "FOV:");
        //fov = GUI.HorizontalSlider(new Rect(60, 105, 100, 30), fov, 60f, 120f);
        //videosetting.setFOV(fov);
        //PlayerPrefs.SetFloat("FOV", fov);

        GUI.Label(new Rect(25, 115, 100, 30), "Shadows:");
        if (GUI.Button(new Rect(25, 135, 75, 20), "None"))
        {
            videosetting.toggleShadows(0);
            shadows = 0;
        }
        if (GUI.Button(new Rect(100, 135, 75, 20), "Hard"))
        {
            videosetting.toggleShadows(1);
            shadows = 1;
        }
        if (GUI.Button(new Rect(175, 135, 75, 20), "Soft"))
        {
            videosetting.toggleShadows(2);
            shadows = 2;
        }
        PlayerPrefs.SetInt("Shadows", shadows);

        GUI.Label(new Rect(25, 165, 100, 30), "Fullscreen:");
        full_bool = GUI.Toggle(new Rect(95, 165, 100, 15), full_bool, "ON/OFF");
        videosetting.setFullScreen(full_bool);
        int full=0;
        if (full_bool == true)
        {
            full = 1;
        }
        else
        {
            full = 0;
        }
        PlayerPrefs.SetInt("FullScreen", full);

        GUI.Label(new Rect(25, 185, 100, 30), "Anti Aliasing:");
        if (GUI.Button(new Rect(25, 205, 75, 20), "0"))
        {
            videosetting.setAA(0);
            AA = 0;
        }
        if (GUI.Button(new Rect(100, 205, 75, 20), "2"))
        {
            videosetting.setAA(2);
            AA = 2;
        }
        if (GUI.Button(new Rect(175, 205, 75, 20), "4"))
        {
            videosetting.setAA(4);
            AA = 4;
        }
        if (GUI.Button(new Rect(250, 205, 75, 20), "8"))
        {
            videosetting.setAA(8);
            AA = 8;
        }
        PlayerPrefs.SetInt("AA", AA);

        GUI.Label(new Rect(25, 235, 100, 30), "VSYNC:");
        vsync_bool = GUI.Toggle(new Rect(95, 235, 100, 15), vsync_bool, "ON/OFF");
        if (vsync_bool)
        {
            videosetting.setVsync(0);
            vSync = 0;
        }
        else
        {
            videosetting.setVsync(1);
            vSync = 1;
        }
        PlayerPrefs.SetInt("VSync", vSync);


        GUI.Label(new Rect(25, 255, 100, 30), "Speaker Type:");

        if (GUI.Button(new Rect(25, 275, 75, 20), "Mono"))
        {
            audiosettings.setAudioType("Mono");
        }
        if (GUI.Button(new Rect(100, 275, 75, 20), "Stereo"))
        {
            audiosettings.setAudioType("Stereo");
        }

        GUI.Label(new Rect(25, 295, 100, 30), "Music Volume:");
        bgVol = GUI.HorizontalSlider(new Rect(120, 300, 100, 30), bgVol, 0f, 1f);
        musicPlayer.volume = bgVol;
        PlayerPrefs.SetFloat("BGVol", bgVol);

        GUI.Label(new Rect(25, 320, 100, 30), "SFX Volume:");
        sfxVol = GUI.HorizontalSlider(new Rect(120, 325, 100, 30), sfxVol, 0f, 1f);
        foreach (AudioSource source in soundEffects)
        {
            source.volume = sfxVol;
        }
        PlayerPrefs.SetFloat("SFXVol", sfxVol);

        GUILayout.EndArea();
    }
}