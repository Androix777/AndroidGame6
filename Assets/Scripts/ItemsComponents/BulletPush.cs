using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPush : MonoBehaviour
{
    DamageDealer damageDealer;
    float force = 1;

    private void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (damageDealer.time == 0) DealDamage(col.gameObject);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (damageDealer.time == 0) DealDamage(col.gameObject);
    }

    private void DealDamage(GameObject target)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        Rigidbody2D rigidbody2D = target.GetComponent<Rigidbody2D>();

        if (damageable != null && damageable.Status != damageDealer.Status && rigidbody2D != null)
        {
            rigidbody2D.AddForce((target.transform.position - transform.position).normalized * force, ForceMode2D.Impulse);
        }
    }

}
