using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem1 : MonoBehaviour, ITrigger
{
    
    void Start()
    {
        gameObject.GetComponent<PlayerController>().shooter.fireRateValue.AddIncrease(-0.1f);
        gameObject.GetComponent<PlayerController>().shooter.projectile.GetComponent<DelayedDeath>().time *=0.85f;
        gameObject.GetComponent<PlayerController>().shooter.projectile.GetComponent<DamageDealer>().damageValue.AddIncrease(10);
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
