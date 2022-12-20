using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource glassSFX;
    [SerializeField] AudioSource shatterSFX;

    public void GlassBreak()
    {
        glassSFX.Play();
    }

    public void GlassShatter()
    {
        shatterSFX.Play();
    }
}
