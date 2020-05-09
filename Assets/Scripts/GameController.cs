using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform player,enemy,finishLine;

    public GameObject winlosetext;
   
    void Update()
    {
        if (player.position.z>=finishLine.position.z)
           {
            player.GetComponent<Car>().Stop();
            DisplayWin();
        }
            }

    void DisplayWin()
    { 

        winlosetext.GetComponent<Text>().text = "You won!";
        winlosetext.SetActive(true);
    }

}
