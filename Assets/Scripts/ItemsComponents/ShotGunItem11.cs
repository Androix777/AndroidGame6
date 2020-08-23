using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem11 : MonoBehaviour, ITrigger
{
    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    [SerializeField] float hpRestore = 1;
    [SerializeField] Life life;

    void Start()
    {
        life = GetComponent<Life>();
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            if (damageDealer.gameObject.GetComponent<TriggerActivator>())
            {
                damageDealer.gameObject.GetComponent<TriggerActivator>().triggers.Add(new Trigger(EventType.DealDamage, this));
            }

        }
    }

    public void ActivateEffect()
    {
        life.TakeDamage(-hpRestore);
    }
}
