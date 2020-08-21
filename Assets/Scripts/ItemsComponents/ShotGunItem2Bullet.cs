using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem2Bullet : MonoBehaviour, ITrigger
{
    [SerializeField] float damageMultiplicator = 1;
    [SerializeField] float radius = 1;
    float damage = 1;
    
    public void Start()
    {
        if (gameObject.GetComponent<DamageDealer>())
        {
            damage = gameObject.GetComponent<DamageDealer>().damageValue.GetStatValue();
        }

        if (gameObject.GetComponent<TriggerActivator>())
        {
            gameObject.GetComponent<TriggerActivator>().triggers.Add(new Trigger(EventType.Death, this));
        }
    }

    public void ActivateEffect()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Life>())
            {
                hitCollider.GetComponent<Life>().TakeDamage(damage * damageMultiplicator);
            }
        }
    }
}
