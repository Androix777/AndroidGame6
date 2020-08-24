using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem2 : MonoBehaviour
{
    [SerializeField] float speed = -1f;
    [SerializeField] float speedIncrease = -0.2f;

    void Start()
    {
        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            damageDealer.gameObject.AddComponent<ShotGunItem2Bullet>();

            if (damageDealer.GetComponent<Move>())
            {
                damageDealer.GetComponent<Move>().speedValue.AddValue(speed);
                damageDealer.GetComponent<Move>().speedValue.AddIncrease(speedIncrease);
            }
        }
    }
}
