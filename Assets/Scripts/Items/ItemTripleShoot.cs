using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTripleShoot : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<PlayerController>().shooter.numOfGuns += 2;
        gameObject.GetComponent<PlayerController>().shooter.angleBetweenGuns = 10;
        gameObject.GetComponent<PlayerController>().shooter.projectile.GetComponent<DelayedDeath>().time *=0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
