using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDeath : MonoBehaviour
{
    public float time;
    private float nowTime;
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
        nowTime += Time.deltaTime;
        if (nowTime >= time)
        {
            if (triggerActivator)
            {
                triggerActivator.ActivateTrigger(EventType.Death);
            }
            Destroy(gameObject);
        }
    }
}
