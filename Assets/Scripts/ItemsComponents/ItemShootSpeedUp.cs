using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShootSpeedUp : MonoBehaviour
{
    private float fireRateMult = 0.2f;
    void Start()
    {
        foreach(Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
            shooter.fireRateValue.AddIncrease(-fireRateMult);
    }

    void Update()
    {
        
    }
}
