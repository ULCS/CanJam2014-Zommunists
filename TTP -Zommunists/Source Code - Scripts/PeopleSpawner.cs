using UnityEngine;
using System.Collections;

public class PeopleSpawner : MonoBehaviour 
{
    public GameObject[] Spawners;
    public static int numSpawners = 50;
    public int spawnNumber;

	// Use this for initialization
    void Start()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Instantiate(Spawners[0], new Vector3(0, 0, 0), Quaternion.identity);
        }
        Instantiate(Spawners[1], new Vector3(0, 2, 0), Quaternion.identity);
        if (Application.loadedLevel == 5)
        {
            Instantiate(Spawners[2], new Vector3(0, -3, 0), Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update() 
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
	}
}
