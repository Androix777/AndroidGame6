using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem5 : MonoBehaviour
{
    [SerializeField] float speedFire = -1f;
    [SerializeField] float speedFireIncrease = -0.2f;

    [SerializeField] Component debuffComponent;

    void Start()
    {

        foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
        {
            shooter.fireRateValue.AddValue(speedFire);
            shooter.fireRateValue.AddIncrease(speedFireIncrease);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
