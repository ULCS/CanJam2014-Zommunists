using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public int selection = 1;
	public GUIText newGame;
	public GUIText select;
	public GUIText Quit;
    float time = 3;
    public GUIText timer;
    private bool countdown;

    public AudioClip pop;

	// Use this for initialization
	void Start () 
	{
        Time.timeScale = 1;
		newGame.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () 
	{
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                AudioSource.PlayClipAtPoint(pop, transform.position);
                if (selection == 1)
                    selection = 3;

                else
                    selection -= 1;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                AudioSource.PlayClipAtPoint(pop, transform.position);
                if (selection == 3)
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
                        Application.LoadLevel(1);
                        break;
                    case 3:
                        Application.Quit();
                        break;
                    default:
                        break;
                }
            }

            switch (selection)
            {
                case 1:
                    newGame.color = Color.red;
                    select.color = Color.white;
                    Quit.color = Color.white;
                    break;
                case 2:
                    select.color = Color.red;
                    newGame.color = Color.white;
                    Quit.color = Color.white;
                    break;
                case 3:
                    Quit.color = Color.red;
                    select.color = Color.white;
                    newGame.color = Color.white;
                    break;
                default:
                    break;
            }
        
	}
}
