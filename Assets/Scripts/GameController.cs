using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TrackInfo
{
    public float zStart;
    public float recommendedScale;
}

public class GameController : MonoBehaviour
{
    public List<TrackInfo> trackInfo;
    public Transform player, enemy, finishLine;
    public GameObject enemycar, track, enemytrack;
    public float maxScale=2f,minScale=0.5f;
    int winlose = 0;
    public GameObject winlosetext, nextlevelbutton;
    public string nextlevel = "2";

    void Update()
    {

        if (winlose == 0 && player.position.z >= finishLine.position.z)
        {
            winlose = 1;
        //    player.GetComponent<Car>().Stop();
         //   enemy.GetComponent<Car>().Stop();
            DisplayWin();
        }
        else if (winlose == 0 && enemy.position.z >= finishLine.position.z)
        {
            winlose = -1;
           // player.GetComponent<Car>().Stop();
           // enemy.GetComponent<Car>().Stop();
            DisplayLose();
        }
    }

    void DisplayWin()
    {
        winlosetext.GetComponent<Text>().text = "You won!";
        winlosetext.SetActive(true);
        nextlevelbutton.SetActive(true);
    }

    void DisplayLose()
    {
        winlosetext.GetComponent<Text>().text = "You lost!";
        winlosetext.SetActive(true);
    }

    void Start()
    {
        SpawnSecondTrack();
        nextlevelbutton.SetActive(false);
    }

    void SpawnSecondTrack()
    {
        Vector3 enemytrackposition = new Vector3(-10, 0, 0),
               enemycarposition = new Vector3(enemytrackposition.x, enemytrackposition.y + 1.5f, enemytrackposition.z);
        Instantiate(track, enemytrackposition, Quaternion.identity);
        enemy = Instantiate(enemycar, enemycarposition, Quaternion.identity).transform;
        enemy.GetComponent< VehicleBehaviour.WheelVehicle >().IsPlayer=false;
        enemy.gameObject.AddComponent<Bot>();
        enemy.GetComponent<Bot>().trackInfo = trackInfo;
    }


    public void ResetRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextlevel);
    }

}
