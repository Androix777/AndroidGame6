using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem4 : MonoBehaviour
{

    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    [SerializeField] float damage = 2f;
    [SerializeField] float damageIncrease = 0.2f;

    [SerializeField] float lifeTimeBullet = -0.1f;

    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            damageDealer.gameObject.AddComponent<ShotGunItem4Bullet>();

            damageDealer.damageValue.AddValue(damage);
            damageDealer.damageValue.AddIncrease(damageIncrease);

            if (damageDealer.GetComponent<DelayedDeath>())
            {
                damageDealer.GetComponent<DelayedDeath>().time += lifeTimeBullet;
            }
        }
    }
}
