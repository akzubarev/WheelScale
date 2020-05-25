using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bot : MonoBehaviour
{
    public List<TrackInfo> trackInfo;

    float maxZ = 0;
    float timestuck = 0f;
    float maxtimestuck = 3f;

    void FixedUpdate()
    {
        if (maxZ + 1 < transform.position.z)
        {
            maxZ = transform.position.z;
            timestuck = 0;

        }
        else
        {
            timestuck += Time.deltaTime;
            if (timestuck >= maxtimestuck)
            {
                StartCoroutine(Optimize(findrecomendedscaling(transform.position.z)));
                timestuck = 0;
            }
        }

    }

    IEnumerator Optimize(float recomended)
    {
        Debug.Log(recomended);
        float delta = (recomended - GetComponent<WheelSize>()._scale) / 100;
        while (recomended - GetComponent<WheelSize>()._scale > delta)
        {
            yield return new WaitForSeconds(0.01f);
            GetComponent<WheelSize>()._scale += delta;
        }
    }

    float findrecomendedscaling(float z)
    {
        for (int i = 0; i < trackInfo.Count; i++)
            if (trackInfo[i].zStart > z)
                return trackInfo[i - 1].recommendedScale;
           
        return 1;
    }
}