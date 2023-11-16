using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedCar : MonoBehaviour {

    void Update ()
    {
        if (GameCntrl.stop)
        {
            foreach (BoxCollider coll in GetComponents <BoxCollider> ())
            {
                coll.enabled = false;
            }
        }
    }
}
