using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem6 : MonoBehaviour
{
    [SerializeField] float angleOffset = 1f;
    [SerializeField] float angleOffsetIncrease = 0.2f;

    [SerializeField] float lifeTime = -0.2f;

    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.angleOffsetValue.AddValue(angleOffset);
            shooter.angleOffsetValue.AddIncrease(angleOffsetIncrease);
        }

        foreach (DamageDealer dealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            dealer.gameObject.AddComponent<ShotGunItem6Bullet>();
            if (dealer.GetComponent<DelayedDeath>())
            {
                dealer.GetComponent<DelayedDeath>().time += lifeTime;
            }
        }
    }
}
