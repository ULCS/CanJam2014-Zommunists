using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            if (Application.loadedLevel == 4) Application.LoadLevel(2);
            else if (Application.loadedLevel == 6) Application.LoadLevel(3);
            else if (Application.loadedLevel == 7) Application.LoadLevel(5);
            else if (Application.loadedLevel == 8) Application.LoadLevel(0);
	}
}
