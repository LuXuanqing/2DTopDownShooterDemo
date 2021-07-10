using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 10;
    public float currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage, HP: {currentHP}/{maxHP}");
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died");
        // TODO: make some animation and vfx
        Destroy(gameObject);
    }
}
