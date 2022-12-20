using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private const string wood = "Wood";
    private const string key = "Key";
    private const string movingPlatform = "MovingPlatform";

    public static event Action OnKeyCollected;

    Rigidbody rb;
    [SerializeField] float turnSpeed = 0.1f;
    [SerializeField] public float chargePower;
    [SerializeField] AudioSource ejectSFX;
    [SerializeField] AudioSource woodSFX;
    [SerializeField] ParticleSystem blueGlow;
    [SerializeField] ParticleSystem redGlow;
    [SerializeField] FloatingJoystick jsInput;
    public bool ballMoving = false;
    public bool chargeInProcess;
    bool onLaunchPad = true;
    bool onMovingPlatform = false;
    float maxChargePower = 50f;
    public Vector3 currentVelocity;
    float currentRotation;

    private const string launchPadTag = ("LaunchPad");

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FireInput();
        ShotCharging();
        ThrowAngle();
        AngleReset();
    }

    void FireInput()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !ballMoving)
        {
            FireAction();
        }
    }

    public void FireAction()
    {
        rb.velocity = transform.up * chargePower;
        ballMoving = true;
        ejectSFX.Play();
        chargeInProcess = false;
        chargePower = 0f;
        var fillAmount = Mathf.Lerp(0, 1, chargePower / maxChargePower);
        UIDisplay.UIDisplaySingleton.UpdateBar(fillAmount);
    }

    public void ShotCharging()
    {
        if (Input.GetKey(KeyCode.Space) && !ballMoving)
        {
            ChargeAction();
            chargeInProcess = true;
        }
    }

    public void ChargeAction()
    {
        chargePower += Time.deltaTime * 25f;
        chargePower = Mathf.Min(chargePower, maxChargePower);
        var fillAmount = Mathf.Lerp(0, 1, chargePower / maxChargePower);
        UIDisplay.UIDisplaySingleton.UpdateBar(fillAmount);
    }

    void ThrowAngle()
    {
        if (ballMoving)
        {
            return;
        }

        var input = new Vector2(jsInput.Horizontal, 0);
        Turn(input.x);

        if (Input.GetKey(KeyCode.A))
        {
            Turn(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Turn(1);
        }
    }

    private void Turn(float inputX)
    {
        transform.Rotate(0, 0, -inputX * turnSpeed * Time.deltaTime);
    }

    public void AngleReset()
    {
        if (rb.velocity.magnitude == 0 && !onMovingPlatform)
        {
            ballMoving = false;

            if (!onLaunchPad)
            {
                rb.transform.rotation = Quaternion.Euler(0, 0, 0);
                onLaunchPad = true;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(launchPadTag))
        {
            onLaunchPad = true;
        }

        else
        {
            onLaunchPad = false;
        }

        if (other.gameObject.CompareTag(wood))
        {
            woodSFX.Play();
        }

        if (other.gameObject.CompareTag(key))
        {
            OnKeyCollected?.Invoke();
            redGlow.Stop();
            blueGlow.Play();
        }
    }

    void MovingAngleReset()
    {
        rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        ballMoving = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(movingPlatform))
        {
            onMovingPlatform = true;
            Invoke("MovingAngleReset", 1f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(movingPlatform))
        {
            ballMoving = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(movingPlatform))
        {
            onMovingPlatform = false;
            ballMoving = true;
        }
    }
}