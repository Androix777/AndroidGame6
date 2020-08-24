using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShotGunItem5 : MonoBehaviour
{
    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    [SerializeField] MonoScript debuffComponent;

    void Start()
    {
        
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            DebuffAdd debuff = damageDealer.gameObject.AddComponent<DebuffAdd>();
            debuff.typeDebuff = debuffComponent;
        }
    }
}
