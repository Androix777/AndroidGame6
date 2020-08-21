using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem6Bullet : MonoBehaviour
{
    [SerializeField] float damageMultiplayer = 0.1f;
    [SerializeField] float damageIncreaseMultiplayer = 0.2f;

    void Start()
    {
        if (GetComponent<DamageDealer>() && GetComponent<Move>())
        {
            GetComponent<DamageDealer>().damageValue.AddValue(damageMultiplayer * GetComponent<Move>().speedValue.GetValue());
            GetComponent<DamageDealer>().damageValue.AddIncrease(damageIncreaseMultiplayer * GetComponent<Move>().speedValue.GetValue());
        }
    }
}
