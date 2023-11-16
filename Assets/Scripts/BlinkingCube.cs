using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingCube : MonoBehaviour {

    void Start ()
    {
        StartCoroutine (Blink ());
    }

    IEnumerator Blink ()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            gameObject.GetComponent<MeshRenderer>().enabled = !gameObject.GetComponent<MeshRenderer>().enabled;
        }
    }
}
