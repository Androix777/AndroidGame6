using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [System.Serializable]
    public class Trigger
    {
        public EventType eventType;
        public Component triggerComponent;
    }
    public Trigger [] triggers;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void ActivateTrigger(EventType selectedEvent)
    {
        foreach(Trigger tr in triggers)
        {
            if(tr.eventType == selectedEvent)
            {
                (tr.triggerComponent as ITrigger).ActivateEffect();
            }
        }
    }
}
