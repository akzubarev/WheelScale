using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRotation : MonoBehaviour
{

    protected void FixedUpdate()
    {
        transform.localRotation= Quaternion.Euler(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
    }
}
