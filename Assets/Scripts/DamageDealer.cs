﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public ValueStat damageValue;
    public int damage;
    [SerializeField] private Status _status = Status.Enemy;
    public Status Status
    {
        get
        { 
            return _status; 
        }
        set
        { 
            _status = value; 
        }
    }
    public bool destroyAfterDealDamage;   
    private TriggerActivator triggerActivator; 

    [SerializeField] private float coolDown = 0.5f; 
    private float time;
    void Start()
    {
        triggerActivator = gameObject.GetComponent<TriggerActivator>();
    }

    void Update()
    {
        time = time-Time.deltaTime > 0? time-Time.deltaTime : 0;
    }

    void OnTriggerStay2D(Collider2D col)
    { 
        if (time == 0) DealDamage(col.gameObject);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (time == 0) DealDamage(col.gameObject);
    }

    private void DealDamage(GameObject target)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null && damageable.Status != Status)
        {
            damageable.TakeDamage(damageValue.GetStatValue());
            time += coolDown;
            if(destroyAfterDealDamage)
            {
                if (triggerActivator)
                {
                    triggerActivator.ActivateTrigger(EventType.Death);
                }
                Destroy(gameObject);
            }
        }
    }
}
