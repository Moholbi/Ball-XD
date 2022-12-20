using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private const string ball = "Ball";

    public static event Action OnBallFinish;

    private          bool           keyCollected;
    private          bool           levelFinished;
    
    [SerializeField] ParticleSystem unlocked;
    [SerializeField] ParticleSystem finish;
    [SerializeField] ParticleSystem locked;

    private void OnEnable()
    {
        BallBehaviour.OnKeyCollected += OnKeyCollected;
    }

    private void OnDisable()
    {
        BallBehaviour.OnKeyCollected -= OnKeyCollected;
    }

    private void OnKeyCollected()
    {
        locked.Stop();
        unlocked.Play();
        keyCollected = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(levelFinished || !keyCollected) return;
        if (other.gameObject.CompareTag(ball))
        {
            OnBallFinish?.Invoke();
            finish.Play();
            unlocked.Stop();
            levelFinished = true;
        }
    }
}