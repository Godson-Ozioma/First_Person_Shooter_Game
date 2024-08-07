using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CollectReward : MonoBehaviour
{
    public SpawnEnemies spawnEnemies;
    public StoryModeWeaponManager weaponManager;
    public GameTipsManager gtm;
    public bool added = false;
    public AudioClip pickUpClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!added)
            {
                weaponManager.unlockedGuns.Add(spawnEnemies.gunReward);
                GetComponent<AudioSource>().PlayOneShot(pickUpClip);
                //Debug.Log(spawnEnemies.gunReward.name);
                string gunName = spawnEnemies.gunReward.name;
                TidyObject.Destroy(spawnEnemies.newReward);
                gtm.ShowHint(gunName + " has been added to my inventory!", 5f);
                added = true;
            }
            
        }
        // add to the unlocked list
        
        //TidyObject.Destroy(spawnEnemies.newReward);
    }
}
