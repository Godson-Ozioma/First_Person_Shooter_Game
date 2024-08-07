using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject enemyPrefab;
    public float spawnInterval;
    public float spawnDuration;
    private Transform currentSpawnLocation;
    public int noOfEnemies;
    public Building building;
    public GameTipsManager gtm;
    public GameObject rewardPrefab;
    public Transform rewardLoc;//location of the reward

    private WaitForSeconds spawnIntervalDuration;
    private float spawnDurationTracker;
    private float spawnTimer;
    public GameObject newReward;
    public GameObject gunReward;
    // Start is called before the first frame update
    void Start()
    {
        spawnIntervalDuration = new WaitForSeconds(spawnInterval);
        spawnTimer = 0.0f;
        spawnDurationTracker = 0.0f;
        noOfEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!building.haveWon)
        {
            spawnTimer += Time.deltaTime;
            spawnDurationTracker += Time.deltaTime;
            if (spawnTimer > spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0;
            }

            CheckWin();
        }
        else
        {
            if(newReward)
            newReward.transform.Rotate(new Vector3(0, 100 * Time.deltaTime, 0));
        }
        
    }

    bool hintShowed = false;
    void CheckWin()
    {
        if (spawnDurationTracker >= spawnDuration && noOfEnemies <= 0 && !building.haveWon)
        {
            Debug.Log("You have won!");
            if (!hintShowed)
            {
                gtm.ShowHint("Wow! I think I've unlocked something...", 5f);
            }

            rewardPrefab.transform.Translate(-1, 0, 0);
            newReward = Instantiate(rewardPrefab, rewardLoc.position, transform.rotation);
            newReward.SetActive(true);
            TidyObject.Destroy(rewardPrefab);

            if(GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(building.winClip);
            }

            building.haveWon = true;
            if (building.location.Equals("Zone 1")) Zone1Controller.haveWon = true;
            if (building.location.Equals("Zone 2")) Zone2Controller.haveWon = true;
            PlayerController.wins++;
            //if (building.location.Equals("Zone 1")) Zone1Controller.haveWon = true;
        }
    }

    private void SpawnEnemy()
    {

        if (spawnDurationTracker < spawnDuration) //keep spawning until spawning time runs out
        {
            int spawnIndex = Random.Range(0, spawnLocations.Length);
            currentSpawnLocation = spawnLocations[spawnIndex];
            Instantiate(enemyPrefab, currentSpawnLocation.position, transform.rotation).SetActive(true);
            noOfEnemies++;
        }

    }
}
