using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    //public Transform[] spawnLocations;
    //public GameObject enemyPrefab;
    //public float spawnInterval;
    //public float spawnDuration;
    public string location;
    public bool haveWon = false;
    public AudioClip winClip;
    public bool doorIsLocked = false;
    //private Transform currentSpawnLocation;

    //private WaitForSeconds spawnIntervalDuration;
    //private float spawnDurationTracker;
    //private float spawnTimer;
    //private int noOfEnemies;

    void Start()
    {
        //spawnIntervalDuration = new WaitForSeconds(spawnInterval);
        //spawnTimer = 0.0f;
        //spawnDurationTracker = 0.0f;
        //noOfEnemies = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!doorIsLocked)
            {
                PlayerController.location = location;
                if (!haveWon)
                    GetComponent<AudioSource>().Play();
            }
            else
            {
                // tell user that the door is locked
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.location = "";
            GetComponent<AudioSource>().Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.location = location;
        }
    }

    public void Update()
    {
       
        //spawnTimer += Time.deltaTime;
        //spawnDurationTracker += Time.deltaTime;
        //if (spawnTimer > spawnInterval)
        //{
        //    SpawnEnemy();
        //    spawnTimer = 0;
        //}

        
    }

    //private void SpawnEnemy()
    //{

    //    if (spawnDurationTracker < spawnDuration) //keep spawning until spawning time runs out
    //    {
    //        int spawnIndex = Random.Range(0, spawnLocations.Length);
    //        currentSpawnLocation = spawnLocations[spawnIndex];
    //        Instantiate(enemyPrefab, currentSpawnLocation.position, transform.rotation).SetActive(true);
    //        noOfEnemies++;
    //    }
        
    //}
}
