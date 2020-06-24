using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public Status status;
    public bool destroyAfterDealDamage;    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        DealDamage(col.gameObject);
    }

    private void DealDamage(GameObject target)
    {
        if (target.GetComponent<Life>() != null && target.GetComponent<Life>().status != status)
        {
            target.GetComponent<Life>().DealDamage(damage);
            if(destroyAfterDealDamage) Functions.DestroyWithDeathEffects(gameObject, deathCause : DeathCause.Time);
        }
    }
}
