using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingEntrance : MonoBehaviour
{
    // location text
    public Image locationTextBg;
    public float textDisplayTime;
    private Text locationTextGUI;

    public GameTipsManager gtm;
    public DoorManager doorManager;

    public Building building;
    private WaitForSeconds textDisplayDuration;

    private void Start()
    {
        locationTextGUI = locationTextBg.GetComponentInChildren<Text>();
        locationTextBg.enabled = false;
        locationTextGUI.enabled = false;
        textDisplayDuration = new WaitForSeconds(textDisplayTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        locationTextGUI.text = building.location;
        if(building.location.Equals("ZONE 2"))
        {
            if(PlayerController.wins < 1)
            {
                gtm.ShowHint("I think I need to kill the enemies in Zone 1 first", 5f);
                return;
            }
            else
            {
                doorManager.DoorCheck();
            }
        }
        if(!building.haveWon)
            gtm.ShowHint("I might win something if I kill all the enemies in this building", 3f);
        StartCoroutine(LocationMessage());
    }

    private void OnTriggerExit(Collider other)
    {
        gtm.HideHint();
    }

    IEnumerator LocationMessage()
    {
        locationTextGUI.text = "LOCATION: " + building.location;
        if (!locationTextGUI.enabled)
        {
            locationTextGUI.enabled = true;
            locationTextBg.enabled = true;
        }
        yield return textDisplayDuration;
        locationTextGUI.enabled = false;
        locationTextBg.enabled = false;
    }
}
