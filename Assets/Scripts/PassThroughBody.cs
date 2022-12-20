using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughBody : MonoBehaviour
{
    public bool passable = true;
    [SerializeField] AudioSource impactSFX;

    public void PassAccess()
    {
        if (passable)
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
