using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Enemy : MonoBehaviour
{
    public float health; // the current health of the enemy

    public float maxHealth = 20;
    public bool isDummy = false;
    public string location;

    private HealthBar healthBar;

    public Animator animator; // used to control the animation of the enemy

    public Building building;

    public AudioClip takeDamageClip;
    public AudioClip dieClip;

    private SpawnEnemies enemies;

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(health);
        location = building.location;

        if(building != null)
            enemies = building.gameObject.GetComponent<SpawnEnemies>();
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            if(takeDamageClip != null) AudioSource.PlayClipAtPoint(takeDamageClip, transform.position);
            health -= damage;

            if(health < 0)
            {
                health = 0;
            }
            
            if (health == 0) //out of health
            {
                if (isDummy)
                {
                    AudioSource.PlayClipAtPoint(dieClip, transform.position);
                    animator.CrossFadeInFixedTime("Dead", 0.01f);
                    TidyObject.DestroyObject(gameObject, 1.0f);
                    PlayerController.kills++;
                    enemies.noOfEnemies--;
                }
                else
                {
                    TidyObject.DestroyObject(gameObject, 0f);
                }
            }
            else
            {
                if (isDummy)
                {
                    animator.CrossFadeInFixedTime("Hit", 0.01f);
                }
            }
            
        }
        healthBar.SetHealth(health);
            
    }
}
