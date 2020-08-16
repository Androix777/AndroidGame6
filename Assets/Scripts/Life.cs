using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour, IDamageable
{
    public ValueStat maxHPValue;
    public float HP;

    public bool Immortal;
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
    private bool dead = false;
    private TriggerActivator triggerActivator; 

    void Start()
    {
        try
        {
            triggerActivator = gameObject.GetComponent<TriggerActivator>();
        }
        catch
        {
            Debug.Log("No TriggerActivator");
        }
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (!Immortal)
        {
            HP -= damage;
        }      
        if (triggerActivator)
        {
            triggerActivator.ActivateTrigger(EventType.GetDamage);
        }
        if (HP <= 0 && !dead)
        {
            if (triggerActivator)
            {
                triggerActivator.ActivateTrigger(EventType.Death);
            }
            Destroy(gameObject);
            dead = true;
        }
    }
}
