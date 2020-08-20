using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamageUp : MonoBehaviour
{
    private int damagePlus = 5;
    void Start()
    {
        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
            damageDealer.damageValue.AddValue(damagePlus);
    }

    void Update()
    {
        
    }
}
