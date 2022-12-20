using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBR : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Cleaner"))
        {
            transform.position = new Vector3(0,50.1800003f,29.7999992f);
            Debug.Log("collided");
        }
    }
}
