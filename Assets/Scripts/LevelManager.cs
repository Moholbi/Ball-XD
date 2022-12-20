using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float levelLoadDelay;

    private void OnEnable()
    {
        BallBehaviour.OnKeyCollected += Unlock;
        FinishLine.OnBallFinish      += OnBallFinish;
    }

    private void OnDisable()
    {
        BallBehaviour.OnKeyCollected -= Unlock;
        FinishLine.OnBallFinish      -= OnBallFinish;
    }

    private void OnBallFinish()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void Unlock()
    {
        gameObject.layer = LayerMask.NameToLayer("Unlocked");
    }
}