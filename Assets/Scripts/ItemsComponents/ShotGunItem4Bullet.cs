using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem4Bullet : MonoBehaviour
{
    DamageDealer damageDealer;
    [SerializeField] float damageDown = 0.1f;
    [SerializeField] float timeDamageDown = 0.1f;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        StartCoroutine(DamageDown());
    }

    IEnumerator DamageDown()
    {
        while (true)
        {
            if (damageDealer) damageDealer.damageValue.AddValue(damageDown);
            else break;
            yield return new WaitForSeconds(timeDamageDown);
        }
    }
}
