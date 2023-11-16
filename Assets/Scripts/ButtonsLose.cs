using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsLose : MonoBehaviour {
    public GameObject buttons, video, carGet;
    private bool done;
    private static int loses = 0;

    void Update ()
    {
        if (PlayerLose.lose && !done)
        {
            buttons.SetActive(true);
            carGet.SetActive(true);
            done = true;
            loses++;
            if (loses % 4 == 0)
                video.SetActive(true);
        }
    }


}
