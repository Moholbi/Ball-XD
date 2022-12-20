using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    [SerializeField] AudioSource blueBall;
    public GameObject ExplosionPrefab;
    float DestroyExplosion = 0.5f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            blueBall.Play();
            var exp = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Destroy(exp, DestroyExplosion);
            Destroy(gameObject, DestroyExplosion);
        }
    }
}