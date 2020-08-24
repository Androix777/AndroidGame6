using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem7 : MonoBehaviour
{
    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    [SerializeField] float numOfGuns = 1f;
    [SerializeField] float numOfGunsIncrease = 0.2f;

    [SerializeField] float speed = 2f;
    [SerializeField] float speedIncrease = 0.2f;

    [SerializeField] float lifeTimeBullet = -0.1f;

    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);

            shooter.numOfGunsValue.AddValue(numOfGuns);
            shooter.numOfGunsValue.AddIncrease(numOfGunsIncrease);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            if (damageDealer.GetComponent<DelayedDeath>())
            {
                damageDealer.GetComponent<DelayedDeath>().time += lifeTimeBullet;
            }

            if (damageDealer.GetComponent<Move>())
            {
                damageDealer.GetComponent<Move>().speedValue.AddValue(speed);
                damageDealer.GetComponent<Move>().speedValue.AddIncrease(speedIncrease);
            }
        }
    }
}
