using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detectGoal : MonoBehaviour
{
    //public static int p1Score = 0;
    //public static int p2Score = 0;
    public GameObject goal;
    public Text p1ScoreText;
    public Text p2ScoreText;

    // Use this for initialization
    void Start ()
    {
        p1ScoreText.text = MCP.p1Score.ToString();
        p2ScoreText.text = MCP.p2Score.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ball")
        {
            Destroy(other.gameObject);
            if(goal.name == "P1(goal)")
            {
                MCP.p2Score += 1;
                p2ScoreText.text = MCP.p2Score.ToString();
                Debug.Log("Goal Player 2");
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
            else if(goal.name == "P2(goal)")
            {
                MCP.p1Score += 1;
                p1ScoreText.text = MCP.p1Score.ToString();
                Debug.Log("Goal Player 1");
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

            }
        }
    }
}
