using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1f;

    float topEdge;
    float botEdge;
    Vector3 distanceBetweenEdges;

    void Start()
    {
        CalculateEdges();

        distanceBetweenEdges = new Vector3(topEdge - botEdge, 0f, 0f);
    }

    void CalculateEdges()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        topEdge = transform.position.y + spriteRenderer.bounds.extents.y / 5f;
        botEdge = transform.position.y - spriteRenderer.bounds.extents.y / 5f;
    }

    void Update()
    {
        transform.localPosition += scrollSpeed * Vector3.down * Time.deltaTime;

        if (PassedEdge())
        {
            MoveTopSpriteToOppositeEdge();
        }
    }

    bool PassedEdge()
    {
        return scrollSpeed > 0 && transform.position.y > topEdge ||
            scrollSpeed < 0 && transform.position.y < botEdge;
    }

    void MoveTopSpriteToOppositeEdge()
    {
        if (scrollSpeed > 0)
            transform.position -= distanceBetweenEdges;
        else
        transform.position += distanceBetweenEdges;
    }
}
