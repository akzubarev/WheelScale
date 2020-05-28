using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Transform player, finishLine;
    
    void Update()
    {
        GetComponent<Slider>().value=player.position.z/finishLine.position.z;     
    }
}
