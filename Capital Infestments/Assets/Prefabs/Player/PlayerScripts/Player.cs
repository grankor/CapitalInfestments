using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GunHolder;
    public GameObject _currentGun;

    public GameObject BloodSplat;

    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FireGun();
        }

        //TODO: Raycast to see whats in front of player. If door and action, open door or close door.
        /*
         * If item, pickup item if room in inventory.  lol, inventory.
         */
    }

    private void FireGun()
    {
        _currentGun.GetComponent<BaseGun>().Shoot();
    }

    private void PickupItem(GameObject item)
    {

    }
}
