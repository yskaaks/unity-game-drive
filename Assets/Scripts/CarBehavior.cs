using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {
    public Color passedColor;
    public float speed = 10f;
    private bool onPlace;

    void Update ()
    {
        if (!onPlace)
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-9f, -0.06f, -10f), speed * Time.deltaTime);
        if (transform.position.x == -9f)
        {
            onPlace = true;
        }
    }
    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Passed")
        {
            CheckClick.click = true;
            other.GetComponent<Renderer>().material.color = passedColor;
        }
    }
}
