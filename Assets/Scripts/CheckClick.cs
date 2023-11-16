using UnityEngine;
using System.Collections;

public class CheckClick : MonoBehaviour
{

    public static bool click;

    void OnMouseDown()
    {
        if (!PlayerLose.lose)
        {
            click = true;
        }
    }

}
