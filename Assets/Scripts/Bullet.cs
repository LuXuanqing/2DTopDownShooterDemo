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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Damage(PlayerShoot.damage);
            Destroy(gameObject);
        }
    }
}
