using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public GameObject EndOfBarrel;
    public GameObject Bullet;

    public float RateOfFire;

    private bool _firing;

    void Start()
    {
        
    }

    private void Update()
    {
    }


    public void Shoot()
    {
        var bullet = Instantiate(Bullet);
        bullet.transform.position = EndOfBarrel.transform.position;
        bullet.transform.rotation = EndOfBarrel.transform.rotation;
    }

}
