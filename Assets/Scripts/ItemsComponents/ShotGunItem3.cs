using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem3 : MonoBehaviour
{

    [SerializeField] float increseDamage = -0.1f;
    [SerializeField] float Damage = -1f;

    [SerializeField] float lifeTimeBullet = -0.1f;

    [SerializeField] float increseBullets = -0.1f;
    [SerializeField] float Bullets = -1f;

    void Start()
    {
        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            damageDealer.damageValue.AddValue(Damage);
            damageDealer.damageValue.AddIncrease(increseDamage);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            if (damageDealer.GetComponent<DelayedDeath>())
            {
                damageDealer.GetComponent<DelayedDeath>().time += lifeTimeBullet;
            }     
        }

        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.numOfGunsValue.AddValue(Bullets);
            shooter.numOfGunsValue.AddIncrease(increseBullets);
        }
    }

}
