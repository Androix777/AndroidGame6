using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDamageDown : MonoBehaviour, IDebuff
{

    [SerializeField] float damage = -1f;
    [SerializeField] float damageIncrease = -0.2f;
    [SerializeField] float time = 1;
    [SerializeField] int numberStacks = 3;

    private void Start()
    {
        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            if (damageDealer != null)
            {
                damageDealer.damageValue.AddValue(damage);
                damageDealer.damageValue.AddIncrease(damageIncrease);
            }

        }
        StartCoroutine(TimerDown());
    }

    IEnumerator TimerDown()
    {
        while (numberStacks > 0)
        {
            numberStacks--;
            yield return new WaitForSeconds(time);
        }

        foreach (DamageDealer damageDealer in gameObject.GetComponent<Core>().spawningDamage)
        {
            if (damageDealer != null)
            {
                damageDealer.damageValue.AddValue(-damage);
                damageDealer.damageValue.AddIncrease(-damageIncrease);
            }
        }
        Destroy(this);
    }

    public void AddStack()
    {
        numberStacks += 3;
    }

    public void Clear()
    {
        
    }
}
