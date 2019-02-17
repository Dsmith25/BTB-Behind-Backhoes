using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    //private static float time = 300;

    void Start()
    {
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            //MCP.time = 300;
            timerText.text = "5:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            MCP.time -= Time.deltaTime;
            string minutes = Mathf.Floor(MCP.time / 60).ToString("00");
            string seconds = (MCP.time % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }
    }
}
