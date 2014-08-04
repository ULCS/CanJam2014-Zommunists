using UnityEngine;
using System.Collections;

public class fencePlacer : MonoBehaviour 
{

    private Vector3 spawnPos = new Vector3(0, 0.5f, -2);
    private Vector3 newPos = new Vector3(0, 0.5f, -2);
    
    private bool fencePlaced;

    // Use this for initialization
	void Start ()
    {
        transform.position = spawnPos;
	}

    // Update is called once per frame
    void Update()
    {
        if (fencePlaced == false)
        {
            float x;
            float y;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                x = transform.position.x + 0.5f;
                //Debug.Log("D");
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                x = transform.position.x - 0.5f;
            }
            else
            {
                x = transform.position.x;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                y = transform.position.y + 0.5f;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                y = transform.position.y - 0.5f;
            }
            else
            {
                y = transform.position.y;
            }

            newPos = new Vector3(x, y, -1);
            transform.position = newPos;

            Vector3 rayStart = transform.position;
            rayStart.z += 1;

            Ray ray = new Ray(rayStart, Vector3.down);
            RaycastHit hit;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) //Left mouse button is pressed
            {
                Vector3 finalPos = new Vector3(transform.position.x, transform.position.y, 0);
                transform.position = finalPos;
                
                if (Physics.Raycast(ray, out hit, 11)) //If the playing space has been clicked
                {
                    //Vector3 fencePosition = Input.mousePosition
                    gameObject.AddComponent("BoxCollider"); //Gives the placed fence a collider
                    fencePlaced = true;
                    audio.Play();
                    FenceSelector.setScore(5);
                    FenceSelector.changeNextFence();
                }
            }
        }

    }

    void OnMouseEnter()
    {
        if (Input.GetButtonDown("Fire2") && fencePlaced == true)
        {
            Ray destructoBeam = new Ray(Input.mousePosition, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(destructoBeam, out hit, 1))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
