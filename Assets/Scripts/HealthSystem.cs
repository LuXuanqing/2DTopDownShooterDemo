using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem
{
    private float health;
    private float maxHealth;
    private Enemy enemy;
    public event EventHandler OnHealthChanged;
    public float Health
    {
        get
        {
            return health;
        }
    }
    public float HealthPercent
    {
        get
        {
            return health / maxHealth;
        }
    }

    // constructor
    public HealthSystem(float maxHealth, Enemy enemy)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.enemy = enemy;
    }

    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0;
            enemy.Die();
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxHealth) health = maxHealth;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }


}
