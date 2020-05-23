using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSize : MonoBehaviour
{
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 2f;

    private float _scale = 1;

    private WheelCollider[] _wheels;

    public float Size => _scale;

    private InputUtils.MobileAxisWrapper _wrapper = new InputUtils.MobileAxisWrapper();
    private void Start()
    {
        _wheels = GetComponentsInChildren<WheelCollider>();
    }

    private void Update()
    {
        float delta = _wrapper.GetAxisValue("Vertical") * 5 * Time.deltaTime;
        _scale = Mathf.Clamp(_scale + delta, _minScale, _maxScale);
    }

    private void FixedUpdate()
    {
        foreach (var w in _wheels)
        {
            w.transform.localScale = new Vector3(1, _scale, _scale);
        }
    }
}
