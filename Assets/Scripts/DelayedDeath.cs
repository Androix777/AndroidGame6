using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDeath : MonoBehaviour
{
    public float time;
    void Start()
    {
        Functions.DestroyWithDeathEffects(gameObject, time, DeathCause.Time);
    }

    void Update()
    {
        
    }
}
