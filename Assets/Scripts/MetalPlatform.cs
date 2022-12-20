using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPlatform : MonoBehaviour
{
    [SerializeField] AudioSource metalSFX;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            metalSFX.Play();
        }
    }
}
