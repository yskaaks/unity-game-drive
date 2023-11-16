using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

    public float delete = -50f;
    [HideInInspector]
    public static float speed = 20f;

    void Update () {

        transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);

        if (transform.position.x < delete)
            Destroy(gameObject);
	}
}
