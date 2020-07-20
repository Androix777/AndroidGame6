using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamageUp : MonoBehaviour
{
    private int damagePlus = 5;
    void Start()
    {
        gameObject.GetComponent<PlayerController>().shooter.projectile.GetComponent<DamageDealer>().damage +=damagePlus;
    }

    void Update()
    {
        
    }
}
