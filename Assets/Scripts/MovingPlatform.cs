using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platformSpeed = 5f;
    public bool rightMovement = true;

    void Update()
    {
        GoingRight();
        GoingLeft();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("RightWall"))
        {
            rightMovement = false;
        }

        if (other.gameObject.tag == ("LeftWall"))
        {
            rightMovement = true;
        }
    }

    void GoingRight()
    {
        if (rightMovement)
        {
            transform.Translate(Vector3.right * platformSpeed * Time.deltaTime);
        }
    }

    void GoingLeft()
    {
        if (!rightMovement)
        {
            transform.Translate(Vector3.left * platformSpeed * Time.deltaTime);
        }
    }
}
