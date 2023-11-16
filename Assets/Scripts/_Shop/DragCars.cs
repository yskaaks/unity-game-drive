using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCars : MonoBehaviour {

    public GameObject cars;
    private Vector3 screenPoint, offset;
    private float lockedYPos;


    void Update()
    {
        if (cars.transform.position.x > 0)
        {
            cars.transform.position = Vector3.MoveTowards (cars.transform.position, new Vector3(0f, cars.transform.position.y, cars.transform.position.z), 10 * Time.deltaTime);
        }
        else if (cars.transform.position.x < -29f)
        {
            cars.transform.position = Vector3.MoveTowards(cars.transform.position, new Vector3(-29f, cars.transform.position.y, cars.transform.position.z), 10 * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (cars.transform.position.x <= 0)
        {
            lockedYPos = screenPoint.x;
            offset = cars.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
    void OnMouseDrag()
    {
        if (cars.transform.position.x <= 0)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition.y = lockedYPos;
            cars.transform.position = curPosition;
        }
    }
    void onMouseUp ()
    {
        if (cars.transform.position.x <= 0)
            Cursor.visible = true;
    }

}
