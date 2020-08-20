using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTripleShoot : MonoBehaviour
{
    void Start()
    {
        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.numOfGunsValue.AddValue(2);
            shooter.angleBetweenGunsValue.SetValue(10);
            shooter.projectile.GetComponent<DelayedDeath>().time *= 0.25f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
