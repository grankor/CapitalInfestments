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
    }

    private void FireGun()
    {
        _currentGun.GetComponent<BaseGun>().Shoot();
    }
}
