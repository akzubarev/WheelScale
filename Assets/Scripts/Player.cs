using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    void FixedUpdate()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
                lp = touch.position;

            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
                lp = touch.position;
        

        float scale = GetComponent<Car>().scaling;
        scale += (lp.x - fp.x) * 2 / Screen.width;
        if (scale > GetComponent<Car>().maxScale)
            scale = GetComponent<Car>().maxScale;
        if (scale < GetComponent<Car>().minScale)
            scale = GetComponent<Car>().minScale;
        fp = lp;
            GetComponent<Car>().scaling=scale;
        }

        if (Input.GetAxis("Vertical") != 0) // user is touching the screen with a single touch
        {
            float scale = GetComponent<Car>().scaling;
            scale += Input.GetAxis("Vertical") / 2;
            if (scale > GetComponent<Car>().maxScale)
                scale = GetComponent<Car>().maxScale;
            if (scale < GetComponent<Car>().minScale)
                scale = GetComponent<Car>().minScale;
            GetComponent<Car>().scaling = scale;
        }
    }

}
