using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlootSplat : MonoBehaviour
{
    private DateTime _despawn;

    void Start()
    {
        _despawn = DateTime.Now.AddSeconds(1);
    }

    // Updte is called once per frame
    void Update()
    {
        if (_despawn < DateTime.Now)
        {
            Destroy(gameObject);
        }
    }
}
