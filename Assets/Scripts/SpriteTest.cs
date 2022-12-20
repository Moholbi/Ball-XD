using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTest : MonoBehaviour
{
    [SerializeField] float cycleSpeed;
    [SerializeField] MeshRenderer meshRenderer;
    Material material;

    void OnEnable()
    {
        material = meshRenderer.sharedMaterial;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 offset = new Vector2 (0, Time.time * cycleSpeed);
        material.mainTextureOffset = offset;
    }
}