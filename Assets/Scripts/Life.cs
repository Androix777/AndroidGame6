using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHP;
    public int HP;
    public Status status;
    private bool dead = false;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0 && !dead)
        {
            Functions.DestroyWithDeathEffects(gameObject, deathCause : DeathCause.Kill);
            dead = true;
        }
    }
}
