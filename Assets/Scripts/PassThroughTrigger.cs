using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughTrigger : MonoBehaviour
{
    [SerializeField] PassThroughBody passThrough;
    [SerializeField] AudioSource passThroughSFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            if (other.gameObject.transform.position.y < transform.position.y)
            {
                passThrough.passable = true;
                passThrough.PassAccess();
            }

            else
            {
                passThrough.passable = false;
                passThrough.PassAccess();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            if (passThrough.passable)
            {
                passThroughSFX.Play();
            }

            {
                passThrough.passable = true;
                passThrough.PassAccess();
            }
        }
    }
}
