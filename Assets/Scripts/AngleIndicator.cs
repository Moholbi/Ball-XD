using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleIndicator : MonoBehaviour
{
    [SerializeField] BallBehaviour ballMovement;
    MeshRenderer body;

    void Start()
    {
        body = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        HideMarker();
    }

    void HideMarker()
    {
        if (!ballMovement.ballMoving)
        {
            body.enabled = true;
        }

        else
        {
            body.enabled = false;
        }
    }
}
