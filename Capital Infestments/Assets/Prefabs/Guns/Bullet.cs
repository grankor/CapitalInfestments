using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Amount of damage done by bullet")]
    public float Damage = 10;

    [Tooltip("Time until bullet despawn")] public float DespawnTime = 15;

    private DateTime _despawnTime;


    private void Start()
    {
        _despawnTime = DateTime.Now.AddSeconds(DespawnTime);
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
            collision.gameObject.GetComponentInParent<BaseNPCEnemy>().Hit(Damage, transform);
            //collision.gameObject.GetComponent<BaseNPCEnemy>().Hit(Damage, transform);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}