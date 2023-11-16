using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameName : MonoBehaviour {

    private float speed = 0.0001f, yPos;

    void start ()
    {
        yPos = transform.position.y;
    }

	// Update is called once per frame
	void Update () {

        if (transform.position.y >= yPos + 0.005f || transform.position.y <= yPos + 0.005f)
        speed = -speed;

        transform.position += new Vector3(0, speed, 0);
	}

}
