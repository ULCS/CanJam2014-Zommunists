using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
    public int selection = 1;
    public GUIText level1;
    public GUIText level2;
    public GUIText level3;
    public GUIText title;

    public AudioClip pop;

	// Use this for initialization
	void Start () 
    {
        level1.color = Color.red;
	}

	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            AudioSource.PlayClipAtPoint(pop, transform.position);
            if (selection == 1)
                selection = 4;
            else
                selection -= 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            AudioSource.PlayClipAtPoint(pop, transform.position);
            if (selection == 4)
                selection = 1;
            else
                selection += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            switch (selection)
            {
                case 1:
                    Application.LoadLevel(4);
                    break;
                case 2:
                    Application.LoadLevel(6);
                    break;
                case 3:
                    Application.LoadLevel(7);
                    break;
                case 4:
                    Application.LoadLevel(0);
                    break;
                default:
                    break;
            }
        }
        
        switch (selection)
        {
            case 1:
                level1.color = Color.red;
                level2.color = Color.white;
                title.color = Color.white;
                break;
            case 2:
                level2.color = Color.red;
                level1.color = Color.white;
                level3.color = Color.white;
                break;
            case 3:
                level3.color = Color.red;
                level2.color = Color.white;
                title.color = Color.white;
                break;
            case 4:
                title.color = Color.red;
                level3.color = Color.white;
                level1.color = Color.white;
                break;
            default:
                break;
        }
	}
}