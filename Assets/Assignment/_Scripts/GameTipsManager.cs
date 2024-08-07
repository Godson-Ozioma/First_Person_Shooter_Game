using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTipsManager : MonoBehaviour
{
    public Image gameTipsImage;
    public Text gameTipsTextGUI;

    //private WaitForSeconds hintDuration;
    private void Start()
    {
        //hintDuration = new WaitForSeconds(hintTime);
        gameTipsImage.enabled = false;
        gameTipsTextGUI.enabled = false;
    }
    public void ShowHint(string message, float hintTime)
    {
        StartCoroutine(ShowHintEffect(message, hintTime));
    }

    public void HideHint()
    {
        StopCoroutine("ShowHintEffect");
    }
    public IEnumerator ShowHintEffect(string message, float hintTime)
    {
        gameTipsTextGUI.text = message;
        gameTipsImage.enabled = true;
        gameTipsTextGUI.enabled = true;
        yield return new WaitForSeconds(hintTime);
        gameTipsImage.enabled = false;
        gameTipsTextGUI.enabled = false;
    }
}
