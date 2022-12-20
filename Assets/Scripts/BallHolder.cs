using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : MonoBehaviour
{

    [SerializeField] MovingPlatform moveRight;
    [SerializeField] MovingPlatform platformSpeed;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Ball"))
        {
            if (moveRight.rightMovement)
            {
                other.gameObject.transform.position += (Vector3.right * platformSpeed.platformSpeed * Time.deltaTime);
            }

            else
            {
                other.gameObject.transform.position += (Vector3.left * platformSpeed.platformSpeed * Time.deltaTime);
            }
        }
    }
}
