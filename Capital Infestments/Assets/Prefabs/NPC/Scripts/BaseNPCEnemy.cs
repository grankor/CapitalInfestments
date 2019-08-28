using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using UnityEngine;
using UnityEngine.AI;

public class BaseNPCEnemy : MonoBehaviour
{
    [Tooltip("MaxHitpoints, Default = 500")] public float MaxHitpoints = 500;
    protected float _currentHitpoints;

    public GameObject BloodSplat;

    private Player _player;
    private NavMeshAgent _nav;
    private Rigidbody _mainRigidBody;
    private CapsuleCollider _mainCollider;

    private List<Rigidbody> _rigidBodies = new List<Rigidbody>();
    private List<Collider> _colliders = new List<Collider>();

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _nav = GetComponent<NavMeshAgent>();
        _mainCollider = GetComponent<CapsuleCollider>();
        _mainRigidBody = GetComponent<Rigidbody>();
        _rigidBodies = GetComponentsInChildren<Rigidbody>().ToList();
        _colliders = GetComponentsInChildren<Collider>().ToList();
        TurnRagdollOff();
        _currentHitpoints = MaxHitpoints;
    }


    private void Update()
    {
        _nav.SetDestination(_player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered {other.gameObject.name}");
        if (other.tag == "Door")
        {
            other.gameObject.GetComponent<DoorController>().OpenDoor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    public void Hit(float damage, Transform hitTransform)
    {
        var blood = Instantiate(BloodSplat);
        blood.transform.position = hitTransform.position;
        blood.transform.rotation = hitTransform.rotation;
        _currentHitpoints -= damage;
        if (_currentHitpoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        TurnRagdollOn();
    }

    private void TurnRagdollOff()
    {

        foreach (var item in _rigidBodies)
        {
            item.isKinematic = true;
        }
        foreach (var item in _colliders)
        {
            item.enabled = false;
        }
        _mainRigidBody.isKinematic = false;
        _mainCollider.enabled = true;
    }

    private void TurnRagdollOn()
    {
       
        foreach (var item in _rigidBodies)
        {
            item.isKinematic = false;
        }
        foreach (var item in _colliders)
        {
            item.enabled = true;
        }
        _mainRigidBody.isKinematic = true;
        _mainCollider.enabled = false;
    }
    
}
