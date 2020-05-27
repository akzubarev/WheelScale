using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Reposition : MonoBehaviour
{ 
    float maxtimeonback = 2f;
    float timeonback = 0;
  public float angleBorder = -0.2f;

    public void FixedUpdate()
    {
        if (Vector3.Dot(transform.up, Vector3.down) >= angleBorder)
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