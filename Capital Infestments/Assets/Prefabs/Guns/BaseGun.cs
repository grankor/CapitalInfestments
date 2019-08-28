using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    [Tooltip("Where Where the bullet spawns")]
    public GameObject EndOfBarrel;
    [Tooltip("Type of projectile")]
    public GameObject Bullet;

    [Tooltip("Time per second that shots take to reset.")]
    public float RateOfFire = 1f;

    private bool _firing;
    private DateTime _resetFireTime;

    void Start()
    {
        _resetFireTime= DateTime.Now;
        ;
    }

    private void Update()
    {
        if (_resetFireTime < DateTime.Now)
        {
            _firing = false;
        }
    }

    public void Shoot()
    {
        if (_firing)
        {
            return;
        }
        var bullet = Instantiate(Bullet);
        bullet.transform.position = EndOfBarrel.transform.position;
        bullet.transform.rotation = EndOfBarrel.transform.rotation;
        _firing = true;
        _resetFireTime = DateTime.Now.AddSeconds(RateOfFire);
    }

}
