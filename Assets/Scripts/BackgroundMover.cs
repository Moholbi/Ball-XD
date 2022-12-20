using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private const string left = "LeftCleaner";
    private const string right = "RightCleaner";
    private const string mid = "MiddleCleaner";

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(left))
        {
            transform.position = new Vector3(-20.6f, 149.7f, 30f);
        }

        if (other.CompareTag(right))
        {
            transform.position = new Vector3(20.7f, 149.7f, 30f);
        }

        if (other.CompareTag(mid))
        {
            transform.position = new Vector3(0f, 149.7f, 30f);
        }
    }
}