using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{

    public List<Trigger> triggers;


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

[System.Serializable]
public class Trigger
{
    public EventType eventType;
    public Component triggerComponent;

    public Trigger()
    {

    }

    public Trigger(EventType eventType, Component triggerComponent)
    {
        this.eventType = eventType;
        this.triggerComponent = triggerComponent;
    }
}
