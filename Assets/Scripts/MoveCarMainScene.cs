using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarMainScene : MonoBehaviour {

	void Update () {
        if (Buttons.moveCar)
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }	
	}
    void OnDestroy ()
    {
        Buttons.moveCar = false;
    }
}
