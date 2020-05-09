using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
}

public class Car : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxScale;
    float scaling = 1;
    public bool moving = true;

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        // visualWheel.transform.position = position;
        //   visualWheel.transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.x,0);
    }

    public void Stop()
    {
        moving = false;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.leftWheel.motorTorque = 0;
            axleInfo.rightWheel.motorTorque = 0;

            axleInfo.leftWheel.transform.localScale = new Vector3(1, 1, 1);
            axleInfo.rightWheel.transform.localScale = new Vector3(1, 1, 1);

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void FixedUpdate()
    {
        if (moving)
        {
            float motor = 400;

            scaling += (lp.x - fp.x) / Screen.width;
            if (scaling > maxScale)
                scaling = maxScale;
            if (scaling < 0.1f)
                scaling = 0.1f;

            fp = lp;
            //scaling=(scaling+Time.deltaTime)%2;
            foreach (AxleInfo axleInfo in axleInfos)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;


                axleInfo.leftWheel.transform.localScale = new Vector3(1, scaling, scaling);
                axleInfo.rightWheel.transform.localScale = new Vector3(1, scaling, scaling);

                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }

        }
    }

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    void Update()
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
        }
    }
}