using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticking : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] BallBehaviour angleReset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Sticky"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            angleReset.AngleReset();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Sticky"))
        {
            rb.useGravity = true;
        }
    }
}
