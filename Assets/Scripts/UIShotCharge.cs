using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIShotCharge : MonoBehaviour
{
    private bool chargePressed;
    [SerializeField] BallBehaviour ballBehaviour;

    void Update()
    {
        Charge();
        ReleaseCharge();
    }

    public void ChargeUI()
    {
        chargePressed = true;
    }

    public void StopChargeUI()
    {
        chargePressed = false;
    }

    void Charge()
    {
        if (chargePressed && !ballBehaviour.ballMoving)
        {
            ballBehaviour.ChargeAction();
        }
    }

    void ReleaseCharge()
    {
        if (ballBehaviour.chargePower > 0 && !chargePressed && !ballBehaviour.chargeInProcess)
        {
            ballBehaviour.FireAction();
        }
    }
}