using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public Status status;
    public bool destroyAfterDealDamage;   
    private TriggerActivator triggerActivator; 

    [SerializeField] private float coolDown = 0.5f; 
    private float time;
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
        if (target.GetComponent<Life>() != null && target.GetComponent<Life>().status != status)
        {
            target.GetComponent<Life>().DealDamage(damage);
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
