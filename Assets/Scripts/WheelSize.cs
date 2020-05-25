using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSize : MonoBehaviour
{
    public float _minScale = 0.85f;
    public float _maxScale = 2f;

    public float _scale = 1;

    private WheelCollider[] _wheels;

    public float Size => _scale;

    private void Start()
    {
        _wheels = GetComponentsInChildren<WheelCollider>();
    }


    private void FixedUpdate()
    {
        foreach (var w in _wheels)
        {
            w.transform.localScale = new Vector3(1, _scale, _scale);
        }
    }
}
