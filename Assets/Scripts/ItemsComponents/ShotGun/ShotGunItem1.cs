using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem1 : MonoBehaviour, ITrigger
{

    [SerializeField]float damagePlus = 10;
    [SerializeField]float lifeTimeBullet = 0.85f;
    [SerializeField]float fireRatePlus = -0.1f;
    [SerializeField] float timeToBuff = 0.5f;

    void Start()
    {
        gameObject.GetComponent<TriggerActivator>().triggers.Add(new Trigger(EventType.Shoot, this));
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddIncrease(fireRatePlus);
            shooter.projectile.GetComponent<DelayedDeath>().time *= lifeTimeBullet;
        }
        StartCoroutine(DamageUp());
    }

    public void ActivateEffect()
    {
        gameObject.GetComponent<PlayerController>().shooter.projectile.GetComponent<DamageDealer>().damageValue.AddIncrease(-damagePlus);
        StartCoroutine(DamageUp());
    }

    IEnumerator DamageUp()
    {
        yield return new WaitForSeconds(timeToBuff);
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.projectile.GetComponent<DamageDealer>().damageValue.AddIncrease(damagePlus);
        }
    }

    void Update()
    {
        
    }
    //Накладывает бафф раз в 2x, немного повышает урон(всех снарядов), уменьшает скорострельность и время жизни снаряда
}
