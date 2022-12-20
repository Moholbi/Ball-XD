using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvizPlatform : MonoBehaviour
{
    MeshRenderer mr;
    float timer = 0f;
    [SerializeField] float invizTimer;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    void Update()
    {
        InvizTrigger();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            mr.enabled = true;
        }
    }

    void InvizTrigger()
    {
        if (mr.enabled)
        {
            timer += Time.deltaTime;
        }

        if (timer > invizTimer)
        {
            mr.enabled = false;
            timer = 0;
        }
    }
}