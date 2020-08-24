using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem10 : MonoBehaviour
{
    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            damageDealer.gameObject.AddComponent<BulletPush>();
        }
    }
}
