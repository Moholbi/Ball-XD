using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBody : MonoBehaviour
{
    [SerializeField] BallBehaviour ballSpeed;
    [SerializeField] AudioManager glassBreak;
    [SerializeField] AudioManager glassShatter;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball") && ballSpeed.currentVelocity.y > 30f)
        {
            glassBreak.GlassBreak();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ball") && ballSpeed.currentVelocity.y < 30f)
        {
            glassShatter.GlassShatter();
        }
    }
}
