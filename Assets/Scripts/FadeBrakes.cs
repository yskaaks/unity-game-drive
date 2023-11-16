using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBrakes : MonoBehaviour {
    public Color col;

    void Start ()
    {
        Destroy(gameObject, 2f);
    }

	void Update () {
        GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, col, 1.4f * Time.deltaTime);
		
	}
}
