using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShootSpeedUp : MonoBehaviour
{
    private float fireRateMult = 0.2f;
    void Start()
    {
        gameObject.GetComponent<PlayerController>().shooter.fireRateValue.AddIncrease(-fireRateMult);
    }

    void Update()
    {
        
    }
}
