using UnityEngine;
using System.Collections;

public class spriteMove : MonoBehaviour {

    private float compensator = 0.3f;

    public static float rot;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = RandomMovement.endPos;
        newPos.x -= compensator;
        newPos.y += compensator;
        transform.position = newPos;

        if (rot > 0)
        {
			transform.rotation = Quaternion.Euler(new Vector3(0,0,rot));
			rot = 0;
        }
	}

    public static void rotateSprite(float v)
    {
        rot = v;
    }
}
