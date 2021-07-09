using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        Vector2 deltaPosition = (Vector2)transform.position - startPosition;
        if (deltaPosition.magnitude >= PlayerShoot.range)
        {
            Destroy(gameObject);
        }
    }
}
