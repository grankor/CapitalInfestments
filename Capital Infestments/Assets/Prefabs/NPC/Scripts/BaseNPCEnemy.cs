using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseNPCEnemy : MonoBehaviour
{
    public GameObject BloodSplat;

    private Player _player;
    private NavMeshAgent _nav;
    private Rigidbody _mainRigidBody;
    private CapsuleCollider _mainCollider;


    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _nav = GetComponent<NavMeshAgent>();
        _mainCollider = GetComponent<CapsuleCollider>();
        _mainRigidBody = GetComponent<Rigidbody>();
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        var colliders = GetComponentsInChildren<Collider>();

        foreach (var item in rigidBodies)
        {
            item.isKinematic = true;
        }
        foreach (var item in colliders)
        {
            item.enabled = false;
        }
        _mainRigidBody.isKinematic = false;
        _mainCollider.enabled = true;
    }


    private void Update()
    {
        _nav.SetDestination(_player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    public void Hit(int damage, Transform hitTransform)
    {
        var blood = Instantiate(BloodSplat);
        blood.transform.position = hitTransform.position;
        blood.transform.rotation = hitTransform.rotation;
    }
}
