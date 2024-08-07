using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUiCanvas;

    private void Start()
    {
        pauseUiCanvas = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        pauseUiCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseUiCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
