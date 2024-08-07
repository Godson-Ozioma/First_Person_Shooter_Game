using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour
{
    public static int wins;
    public static string location = ""; // the current building the player is inside
    public float maxHealth = 150;
    public HealthBar healthBar;
    public AudioClip takeDamageClip;
    public GameObject gameOverGui;
    public static int kills;
    public Text killsGUI;
    //public CameraShake cameraShake;

    private float health;
    private bool gameOver;
    private void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
        gameOver = false;
        killsGUI.text = "0";
    }

    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            if(takeDamageClip != null) GetComponent<AudioSource>().PlayOneShot(takeDamageClip);
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.5f);
            //if (cameraShake != null) StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            healthBar.SetHealth(health); //update the health bar
            Debug.Log("Player Health" + health);
        }
       
    }

    void CheckGameOver()
    {
        if(health <= 0)
        {
            gameOver = true;
        }
    }

    private void FixedUpdate()
    {
        CheckGameOver();
        if (gameOver)
        {
            Time.timeScale = 0f;
            gameOverGui.SetActive(true);
        }
    }

    private void Update()
    {
        killsGUI.text = kills.ToString();
    }


}
