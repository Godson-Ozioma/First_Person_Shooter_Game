using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModeWeaponManager : MonoBehaviour
{
    public List<GameObject> unlockedGuns;
    public int selectedGunIndex = 0;
    private GameObject currGun;

    //private void Start()
    //{
    //    currGun = unlockedGuns[selectedGunIndex];
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(selectedGunIndex > 0)
            {
                currGun = unlockedGuns[selectedGunIndex];
                currGun.SetActive(false);

                selectedGunIndex--;

                unlockedGuns[selectedGunIndex].SetActive(true);
            }
            else
            {
                currGun = unlockedGuns[selectedGunIndex];
                currGun.SetActive(false);

                selectedGunIndex = unlockedGuns.Count - 1;

                unlockedGuns[selectedGunIndex].SetActive(true);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (selectedGunIndex < unlockedGuns.Count-1)
            {
                currGun = unlockedGuns[selectedGunIndex];
                currGun.SetActive(false);

                selectedGunIndex++;

                unlockedGuns[selectedGunIndex].SetActive(true);
            }
            else
            {
                currGun = unlockedGuns[selectedGunIndex];
                currGun.SetActive(false);

                selectedGunIndex = 0;

                unlockedGuns[selectedGunIndex].SetActive(true);
            }

        }
    }
    //public int selectedWeapon = 0;

    //public void InputManager()
    //{
    //    if (Input.GetKeyDown(KeyCode.V)) // next weapon
    //    {
    //        if(selectedWeapon < transform.childCount - 1)
    //        {
    //            Transform currWeapon = transform.GetChild(selectedWeapon);
    //            Transform nextWeapon = transform.GetChild(selectedWeapon + 1);
    //            WeaponController nextWeaponController = nextWeapon.GetComponent<WeaponController>();
    //            if (nextWeaponController.unlocked)
    //            {
    //                //switch
    //                currWeapon.gameObject.SetActive(false);
    //                nextWeapon.gameObject.SetActive(true);
    //                selectedWeapon++;
    //            }
    //            else
    //            {
    //                Debug.Log("Locked");
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("Last Weapon");
    //        }


    //    }

    //    if (Input.GetKeyDown(KeyCode.X)) // prev weapon
    //    {
    //        if (selectedWeapon > 0)
    //        {
    //            Transform currWeapon = transform.GetChild(selectedWeapon);
    //            Transform nextWeapon = transform.GetChild(selectedWeapon - 1);
    //            WeaponController nextWeaponController = nextWeapon.GetComponent<WeaponController>();
    //            if (nextWeaponController.unlocked)
    //            {
    //                //switch
    //                currWeapon.gameObject.SetActive(false);
    //                nextWeapon.gameObject.SetActive(true);
    //                selectedWeapon--;
    //            }
    //            else
    //            {
    //                Debug.Log("Locked");
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("First Weapon");
    //        }
    //    }
    //}

    //private void Update()
    //{
    //    InputManager();
    //}
}
