using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

    public float speed = 0.1f;
    private float yPos;

    void Start ()
    {
        speed = Random.Range(0, 10) > 5 ? speed : -speed;

        yPos = transform.position.y; 
    }

	void Update () {
        if (transform.position.y >= yPos + 2.5f || transform.position.y <= yPos - 2.5f)
            speed = -speed; 
        transform.position += new Vector3(0, speed, 0);
	
	}
}   
