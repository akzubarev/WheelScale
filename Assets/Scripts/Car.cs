using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool working;
}

public class Car : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxScale=2f,minScale=0.5f;
    public float scaling = 1;
    public bool moving = true;


    public void Start()
    { 
        maxScale = GameObject.Find("GameController").GetComponent<GameController>().maxScale;    
        minScale = GameObject.Find("GameController").GetComponent<GameController>().minScale;    
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

      //   visualWheel.transform.position = position;
         visualWheel.transform.rotation = rotation;
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

    float maxtimeonback = 2f;
    float timeonback = 0;
  
    public void FixedUpdate()
    {
        if (moving)
        {
            float motor = maxMotorTorque/scaling;

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.working)
                { 
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }

                axleInfo.leftWheel.transform.localScale = new Vector3(1, scaling, scaling);
                axleInfo.rightWheel.transform.localScale = new Vector3(1, scaling, scaling);

                axleInfo.leftWheel.steerAngle = 0;
                axleInfo.rightWheel.steerAngle = 0;

                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }

        }
     //   Debug.Log(Vector3.Dot(transform.up, Vector3.down));
        if (Vector3.Dot(transform.up, Vector3.down) >= -0.1)
        {
            timeonback += Time.deltaTime;
            if (timeonback >= maxtimeonback)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                transform.localRotation = Quaternion.identity;
                timeonback = 0;
            }
        }
        else 
            timeonback=0;
    }
  

}