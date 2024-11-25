using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class OBJ_Hurdle_Roller : MonoBehaviour
{
    protected Rigidbody _rb;
    [SerializeField] protected Vector3 _rotateSpeed;
    [SerializeField] private Transform _com;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _com.position - transform.position;
    }

    protected virtual void FixedUpdate()
    {
        _rb.angularVelocity = _rotateSpeed;
    }
}