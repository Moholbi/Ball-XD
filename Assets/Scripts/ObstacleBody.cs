using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBody : MonoBehaviour
{
    public bool passBlocked = true;
    [SerializeField] AudioSource impactSFX;

    public void WayBlock()
    {
        if (passBlocked)
        {
            gameObject.layer = LayerMask.NameToLayer("Passable");
        }

        else
        {
            gameObject.layer = LayerMask.NameToLayer("Impassable");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        impactSFX.Play();
    }
}
