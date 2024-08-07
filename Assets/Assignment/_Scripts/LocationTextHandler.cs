using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationTextHandler : MonoBehaviour
{
    public static Building building;
    public static float locationDisplayTime;

    public static WaitForSeconds locationDuration;
    public static Text text;

    private void Start()
    {
        locationDuration = new WaitForSeconds(locationDisplayTime);
        text = GetComponent<Text>();
        text.enabled = false;
    }

    public static IEnumerator ShowLocationMessage()
    {

        text.text = building.location;
        if (!text.enabled)
        {
            text.enabled = true;
        }
        yield return locationDuration;
        text.enabled = false;
    }
}
