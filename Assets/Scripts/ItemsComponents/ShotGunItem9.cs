using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem9 : MonoBehaviour
{
    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    [SerializeField] float lifeTimeBullet = -0.1f;

    [SerializeField] float damage = 0.1f;
    [SerializeField] float damageIncrease = 0.2f;

    PlayerController playerController;
    bool move = false;


    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            if (damageDealer.GetComponent<DelayedDeath>())
            {
                damageDealer.GetComponent<DelayedDeath>().time += lifeTimeBullet;
            }
        }

        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            if (playerController != move)
            {
                move = playerController;

                foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
                {
                    shooter.fireRateValue.AddValue(damage * (move? 1:-1));
                    shooter.fireRateValue.AddIncrease(damageIncrease * (move ? 1 : -1));
                }
            } 
        }
    }
}
