using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField] ObstacleBody obstacleBody;
    [SerializeField] AudioSource passThroughSFX;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            if (other.gameObject.transform.position.y > transform.position.y)
            {
                obstacleBody.passBlocked = true;
                obstacleBody.WayBlock();
            }

            else
            {
                obstacleBody.passBlocked = false;
                obstacleBody.WayBlock();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Ball") && obstacleBody.passBlocked)
        {
            passThroughSFX.Play();

            if (other.gameObject.transform.position.y < transform.position.y)
            {
                obstacleBody.passBlocked = false;
                obstacleBody.WayBlock();
            }
        }
    }
}