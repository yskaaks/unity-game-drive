using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeft : MonoBehaviour {

    public float speed = 5f;
    private RectTransform rec;

    void Start()
    {
        rec = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rec.offsetMin.x != 0)
        {
            rec.offsetMin += new Vector2(speed, rec.offsetMin.y);
            rec.offsetMax += new Vector2(speed, rec.offsetMax.y);
        }
    }
}
