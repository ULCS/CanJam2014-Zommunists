using UnityEngine;
using System.Collections;

public class ScoreTimer : MonoBehaviour 
{
    public float time = 5;
    public float stime = 3;
    public GUIText timer;
    public GUIText result;
    public int finalScore;
    public char rank;

    private bool levelOver;

	// Use this for initialization
	void Start () 
    {
        levelOver = false;
	}
	
	// Update is called once per frame
	void Update() 
    {
        int currentScore = FenceSelector.getScore();
        if (currentScore == 0) time = 1;
        
        time = time - Time.deltaTime;
        timer.text = Mathf.Round(time) + "/60";
        Debug.Log(Mathf.Round(time) + "/60");
        if (time < 1)
        {
            Time.timeScale = 0;
            finalScore = FenceSelector.getScore();
            Debug.Log(finalScore);
            if (finalScore >= 900) rank = 'S';
            else if (finalScore >= 800) rank = 'A';
            else if (finalScore >= 600) rank = 'B';
            else if (finalScore >= 500) rank = 'C';
            else if (finalScore >= 400) rank = 'D';
            else rank = 'F';
            result.text = "Your Rank: " + rank + "!";
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                levelOver = true;
            }
            if (levelOver)
            {
                if (rank != 'F')
                {
                    Time.timeScale = 1;
                    stime = stime - Time.deltaTime;
                    result.text = Mathf.Round(stime) + "!";
                    if (stime < 1)
                    {
                        if (Application.loadedLevel == 2) Application.LoadLevel(6);
                        else if (Application.loadedLevel == 3) Application.LoadLevel(7);
                        else if (Application.loadedLevel == 5) Application.LoadLevel(8);
                    }
                }
                else
                {
                    Time.timeScale = 1;
                    stime = stime - Time.deltaTime;
                    result.text = Mathf.Round(stime) + "!";
                    if (stime < 1) restartLevel();
                }
            }
        }
	}

    void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
