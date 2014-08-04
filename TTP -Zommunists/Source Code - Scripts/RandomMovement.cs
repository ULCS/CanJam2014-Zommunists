using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    private float maxX = 8.5f;
    private float minX = -8.5f;
    private float maxY = 4.5f;
    private float minY = -4.5f;
    private float tChange = 0f;
    private float randomX;
    private float randomY;
    public float moveSpeed = 5;
    private float xSpeed;
    private float ySpeed;
    public static Vector3 endPos;
    private Vector3 previousPosition;

    public GameObject revolution;
    public GameObject l3Rev;

    public AudioClip hit;

    void Start()
    {
        if (tag != "Revolution" && tag != "Infector")
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }
        previousPosition = transform.position;
    }

    void Update()
    {    
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-2.0f, 2.0f); // with float parameters, a random float
            randomY = Random.Range(-2.0f, 2.0f); //  between -2.0 and 2.0 is returned
            tChange = Time.time + Random.Range(0.5f, 1.5f); // set a random interval between 0.5 and 1.5
        }

        transform.Translate(new Vector3(randomX, randomY, 0) * moveSpeed * Time.deltaTime);
        // if object reached any border, revert the appropriate direction
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            randomX = -randomX;
        }
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            randomY = -randomY;
        }

        //transform.position += new Vector3(randomX * Time.deltaTime, randomY*Time.deltaTime, 0);
        rigidbody.AddForce(randomX * Time.deltaTime, randomY * Time.deltaTime, 0);

        // make sure the position is inside the borders
        Vector3 thing = transform.position;
        thing.x = Mathf.Clamp(transform.position.x, minX, maxX);
        thing.y = Mathf.Clamp(transform.position.y, minY, maxY);
        endPos = transform.position = thing;


        //rotating the sprite.

        float deltaX = transform.position.x - previousPosition.x;
        float deltaY = transform.position.y - previousPosition.y;

        float rotateAmount = Mathf.Atan(deltaY / deltaX);

        spriteMove.rotateSprite(rotateAmount);

        previousPosition = transform.position;

        

    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Revolution")
        {
            if (gameObject.tag != "Infector")
            {
                Instantiate(revolution, transform.position, Quaternion.identity);
                FenceSelector.setScore(20);
            }
            else
            {
                FenceSelector.setScore(10);
            }
            AudioSource.PlayClipAtPoint(hit, transform.position); 

            Destroy(gameObject);
            
            Debug.Log("Collision");

        }
        if (c.gameObject.tag == "Infector")
        {
            if (gameObject.tag != "Revolution")
            {
                Instantiate(l3Rev, transform.position, Quaternion.identity);
                Destroy(gameObject);
                FenceSelector.setScore(20);
                AudioSource.PlayClipAtPoint(hit, transform.position);
            }
 
            Debug.Log("Collision");
        }

        else
        {
            //Debug.Log("Collision");
            rigidbody.velocity = (rigidbody.velocity * -1);
            randomX = -randomX;
            randomY = -randomY;
        }
    }

    
}