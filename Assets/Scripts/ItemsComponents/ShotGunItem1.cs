using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem1 : MonoBehaviour, ITrigger
{
    
    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddIncrease(-0.1f);
            shooter.projectile.GetComponent<DelayedDeath>().time *= 0.85f;
            shooter.projectile.GetComponent<DamageDealer>().damageValue.AddIncrease(10);
        }
    }

    public void ActivateEffect()
    {
        gameObject.GetComponent<PlayerController>().shooter.projectile.GetComponent<DamageDealer>().damageValue.AddIncrease(-10);
    }


    void Update()
    {
        
    }
    //Накладывает бафф раз в 2x, немного повышает урон(всех снарядов), уменьшает скорострельность и время жизни снаряда
}
