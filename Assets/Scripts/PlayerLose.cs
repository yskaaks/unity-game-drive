using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour {
    public static bool lose;
    public GameObject explosion;

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Car")
        {
            print("Player Lose");
            lose = true;
            MoveObjects.speed = 0;
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 150);

            
        }
    }
    void OnDestroy ()
    {
        lose = false;
    }

}
