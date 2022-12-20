using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySound : MonoBehaviour
{
    [SerializeField] AudioSource stickSFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            stickSFX.Play();
        }
    }
}
