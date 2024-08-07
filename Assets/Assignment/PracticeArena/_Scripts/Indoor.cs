using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indoor : MonoBehaviour
{
    public static bool playerIn = false; // true if the player is in the building

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            playerIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerIn = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerIn = true;
    }
}
