using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRotation : MonoBehaviour
{

    protected void FixedUpdate()
    {
         GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
      //  transform.localRotation= Quaternion.Euler(transform.localEulerAngles.x, 0f, 0f);
        GetComponent<Rigidbody>().velocity = new Vector3(0f,GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(GetComponent<Rigidbody>().angularVelocity.x, 0f, 0f);
 
        }
}
