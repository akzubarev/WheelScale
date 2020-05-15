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
    public GameObject winlosetext;

    void Update()
    {

        if (winlose == 0 && player.position.z >= finishLine.position.z)
        {
            winlose = 1;
            player.GetComponent<Car>().Stop();
            enemy.GetComponent<Car>().Stop();
            DisplayWin();
        }
        else if (winlose == 0 && enemy.position.z >= finishLine.position.z)
        {
            winlose = -1;
            player.GetComponent<Car>().Stop();
            enemy.GetComponent<Car>().Stop();
            DisplayLose();
        }
    }

    void DisplayWin()
    {
        winlosetext.GetComponent<Text>().text = "You won!";
        winlosetext.SetActive(true);
    }

    void DisplayLose()
    {
        winlosetext.GetComponent<Text>().text = "You lost!";
        winlosetext.SetActive(true);
    }

    void Start()
    {
        SpawnSecondTrack();
    }

    void SpawnSecondTrack()
    {
        Vector3 enemytrackposition = new Vector3(-10, 0, 0),
               enemycarposition = new Vector3(enemytrackposition.x, enemytrackposition.y + 1.5f, enemytrackposition.z);
        Instantiate(track, enemytrackposition, Quaternion.identity);
        enemy = Instantiate(enemycar, enemycarposition, Quaternion.identity).transform;
        enemy.GetComponent<Bot>().trackInfo = trackInfo;
    }


    public void ResetRace()
    {
        /*
        player.position = new Vector3(0, 1.5f, 0);
        player.localRotation = Quaternion.identity;
        player.GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        enemy.position = new Vector3(-10, 1.5f, 0);
        enemy.localRotation = Quaternion.identity;
        enemy.GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
        enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemy.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    */
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
