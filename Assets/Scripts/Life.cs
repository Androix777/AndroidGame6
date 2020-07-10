using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHP;
    public int HP;

    public bool Immortal;
    public Status status;
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

    public void DealDamage(int damage)
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
