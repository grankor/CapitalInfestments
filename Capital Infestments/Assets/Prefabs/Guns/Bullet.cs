using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private DateTime _despawnTime;


    private void Start()
    {
        _despawnTime = DateTime.Now.AddSeconds(15);
    }

    void Update()
    {
        if (_despawnTime < DateTime.Now)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * 20 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            collision.gameObject.GetComponent<BaseNPCEnemy>().Hit(1, transform);
        }
    }
}
