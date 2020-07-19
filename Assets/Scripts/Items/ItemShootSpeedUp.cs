using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShootSpeedUp : MonoBehaviour
{
    private float fireRateMult = 0.8f;
    void Start()
    {
        gameObject.GetComponent<PlayerController>().shooter.fireRate *= fireRateMult;
    }

    void Update()
    {
        
    }
}
