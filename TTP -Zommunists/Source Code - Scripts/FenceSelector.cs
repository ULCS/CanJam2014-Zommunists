using UnityEngine;
using System.Collections;

public class FenceSelector : MonoBehaviour {

	
    //score is also stored in this script to save on excess objects.
    private static int score;

    public GameObject[] fences;
	public int fenceMax;

	private static bool fencePlaced = true; //Allows player to place a fence at start

	private static GameObject currentFence;
    private static GameObject nextFence;

	private int fenceNum;

	// Use this for initialization
	void Start ()
	{
        int numPeople = PeopleSpawner.numSpawners;
        score = 20 * numPeople;
        
        FenceSelection(); //On startup, a fence prefab should be determined
	}
	
	// Update is called once per frame
    public void Update()
	{
		if (fencePlaced == true)
		{
			FenceSelection();//Select/generate next fence
			fencePlaced = false; //Stops new prefab generation until fence is placed
		}

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        nextFence.transform.position = Vector2.Lerp(transform.position, mousePosition, 7); ;
	}


	void FenceSelection()
	{
		fenceNum = Random.Range(0,fenceMax); //Determines which fence prefab to instantiate

		Vector3 windowPos = new Vector3(0, 0, 0f);

		nextFence = fences[fenceNum];
		Instantiate(nextFence, windowPos, Quaternion.identity); // as GameObject
	}

    public static void changeNextFence()
    {
        currentFence = nextFence;
        fencePlaced = true;
    }

    public static void setScore(int c)
    {
        score -= c;
        Debug.Log(score);
    }

    public static int getScore()
    {
        return score;
    }
}
