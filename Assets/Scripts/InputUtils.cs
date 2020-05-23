using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputUtils
{ 
    public class MobileAxisWrapper
    {
        private Vector3? _lastTouch = null;

        public float GetAxisValue(string axisName)
        {
            if (Application.isMobilePlatform)
            {
                if (Input.touchCount == 1)
                {
                    var touchPos = Input.GetTouch(0).position;

                    if (_lastTouch == null)
                        _lastTouch = touchPos;

                    switch (axisName)
                    {
                        case "Vertical":
                            return (touchPos.y - _lastTouch.Value.y) / Screen.height;
                        case "Horizontal":
                            return (touchPos.x - _lastTouch.Value.x) / Screen.width;
                    }
                } else
                {
                    _lastTouch = null;
                }
            }

            try
            {
                return Input.GetAxis(axisName);
            }
            catch { }

            return 0;
        }
    }
 
}
