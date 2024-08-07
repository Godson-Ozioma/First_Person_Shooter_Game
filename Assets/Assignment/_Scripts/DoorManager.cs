using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorManager : MonoBehaviour
{
    bool doorIsOpen = false;
    public float isOpenTime = 3.0f;
    float openDoorTimer;
    public AudioClip doorOpenClip;
    public AudioClip doorCloseClip;
    // Start is called before the first frame update
    void Start()
    {
        openDoorTimer = 0.0f;
    }

    /**
     * Used in the OnTriggerEnter() in the TriggerZone script
     */
    public void DoorCheck()
    {
        if (!doorIsOpen)
        {
            //open the door
            gameObject.SetActive(false);
        }
    }

    IEnumerator Door()
    {
        //play sound
        GetComponent<AudioSource>().PlayOneShot(doorOpenClip);
        //open
        transform.parent.GetComponent<Animation>().Play("dooropen");
        doorIsOpen = true;

        yield return new WaitForSeconds(isOpenTime);

        // close
        GetComponent<AudioSource>().PlayOneShot(doorCloseClip);
        transform.parent.GetComponent<Animation>().Play("doorshut");
        doorIsOpen = false;


    }
}
