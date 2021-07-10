using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform healthBarPrefab;
    private HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject == this)
        {
            Debug.Log(true);
        }
        // instantiate health bar, set its parent
        Transform healthBarTransform = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBarTransform.SetParent(transform);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthSystem = new HealthSystem(10, this);
        healthBar.Setup(healthSystem);

        // test
        Debug.Log($"health:{healthSystem.HealthPercent}");
        healthSystem.Damage(6);
        Debug.Log($"health:{healthSystem.HealthPercent}");
        healthSystem.Heal(1);
        Debug.Log($"health:{healthSystem.HealthPercent}");
    }

    public void Die()
    {
        // TODO: make some animation and cool vfx
        Debug.Log($"{gameObject.name} die");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            healthSystem.Damage(PlayerShoot.damage);
        }
    }
}
