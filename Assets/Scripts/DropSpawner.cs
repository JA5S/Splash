using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages drop Prefab spawning
public class DropSpawner : MonoBehaviour
{
    //declare variables
    public GameObject waterDrop;

    private float scrWth;
    private float initDelay = 1;
    private float repeatDelay = 1;
    public WaterMeter waterMeter;
    public GameManager gameManager;

    void Start()
    {
        //calc screen width in units from pixels
        scrWth = Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;

        //spawn drops
        InvokeRepeating("SpawnDrops", initDelay, repeatDelay);
    }

    //while game is running spawns drops, destroys drops after game ends
    void SpawnDrops()
    {
        if (!waterMeter.gameOver && gameManager.gameHasStarted)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-scrWth+1, scrWth-1), transform.position.y, 0);
            Instantiate(waterDrop, spawnPos, waterDrop.transform.rotation);
        }
        else
        {
            foreach (GameObject drop in GameObject.FindGameObjectsWithTag("Drop"))
            {
                Destroy(drop);
            }
        }
    }
}
