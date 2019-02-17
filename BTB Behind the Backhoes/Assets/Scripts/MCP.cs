using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP : MonoBehaviour
{
    private static MCP instance;
    public static int p1Score = 0;
    public static int p2Score = 0;
    public static float time = 300f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
