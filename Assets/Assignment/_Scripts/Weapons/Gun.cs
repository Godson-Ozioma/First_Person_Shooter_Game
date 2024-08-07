using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Gun : MonoBehaviour
{
    public float shotDamage = 2.0f; // damage the gun will render to an enemy when shot
    public float weaponRange = 50.0f; // range of the bullet when fired
    public float fireRate = 0.25f; // how often the bullet can fire
    public int magCapacity = 40; // capacity of the magazine in the bullet
    public int resBullets = 80; // reserve bullets (bullets not in magazine)
    public float reloadTime; // how fast the gun can reload
    public bool isAutomatic = true; // if the gun is automatic or not

    public Transform muzzlePosition; // position of the muzzle of the gun
    public AudioClip sound; // the sound the gun makes when fired

    public ParticleSystem bulletImpact;
    public ParticleSystem muzzleFlash;

    private int bulletsInMag; // number of currently bullets in the magazine
    private WaitForSeconds reloadDuration;
    private float fireTimer; // used to keep track of fire freq and effect fire rate better
    private Camera fpsCam;
    private bool isReloading; // true if the gun is currently reloading
    private Animator animator; // reference to the animator component of the gun
    

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        bulletsInMag = magCapacity; //start the game with full ammo
        reloadDuration = new WaitForSeconds(reloadTime);
        fpsCam = GetComponentInParent<Camera>();
        isReloading = false;
    }

    void DisplayBullets()
    {
        Debug.Log(bulletsInMag + " / " + resBullets);
    }

    void Shoot()
    {
        if (fireTimer < fireRate) return;

        if (!isReloading)
        {
            muzzleFlash.Play();
            GetComponent<AudioSource>().PlayOneShot(sound); // play the gunshot sound
            animator.CrossFadeInFixedTime("Fire", 0.01f); //play the fire animation
            
            bulletsInMag--;  // reduce the number of bullets in the magazine

            DisplayBullets();



            // Raycast 
            //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;

            if (Physics.Raycast(muzzlePosition.position, muzzlePosition.transform.forward, out hit, weaponRange)) // the ray hit an object
            {
                Debug.DrawRay(muzzlePosition.position, muzzlePosition.transform.forward, Color.green);
                ParticleSystem impact = Instantiate(bulletImpact, hit.point, hit.transform.rotation);
                TidyObject.Destroy(impact, 0.5f);
                //Debug.Log(hit.transform.name);
                
                // if the ray hit an enemy
                if (hit.transform.GetComponent<Enemy>() != null)
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    enemy.TakeDamage(shotDamage);
                }
            }

        }
        fireTimer = 0.0f; // reset fire timer
    }

    void Reload()
    {
        if (resBullets > 0 && bulletsInMag < magCapacity) //if there are reserve bullets and the magazine is not full
        {
            StartCoroutine(ReloadEffect()); // reload animation
            int noOfBulletsNeeded = magCapacity - bulletsInMag; //amount of bullets needed to be added to the magazine
            if (resBullets >= noOfBulletsNeeded)
            {
                resBullets -= noOfBulletsNeeded;
                bulletsInMag += noOfBulletsNeeded;
            }
            else
            {
                bulletsInMag += resBullets;
                resBullets = 0;
            }
            DisplayBullets();
        }
    }

    IEnumerator ReloadEffect()
    {
        // reload animation
        isReloading = true;
        yield return reloadDuration;
        isReloading = false;
    }

    void CheckFireTimer()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    void CheckUserInput()
    {
        //Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        // Shoot
        if (isAutomatic) // automatic guns
        {
            if (Input.GetButton("Fire1"))
            {
                if (bulletsInMag > 0)
                {
                    Shoot();
                }
                else
                {
                    Reload();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (bulletsInMag > 0)
                {
                    Shoot();
                }
                else
                {
                    Reload();
                }
            }
        }
        
    }

    void StopFireAnimation()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0); //get 1st layer
        //prevent the animation from playing forever
        if (info.IsName("Fire")) //if fire animation is being played
        {
            animator.SetBool("Fire", false); //stop the animation
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckFireTimer(); //check if the gun can be fired because of its fire rate
        CheckUserInput(); //check for input
    }

    private void FixedUpdate()
    {
        //StopFireAnimation();
    }
}
