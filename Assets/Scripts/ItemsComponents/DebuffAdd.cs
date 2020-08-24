using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebuffAdd : MonoBehaviour
{
    public MonoScript typeDebuff;
    [SerializeField]DamageDealer dealer;

    private void Start()
    {
        dealer = GetComponent<DamageDealer>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        AddDebuff(col.gameObject);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        AddDebuff(col.gameObject);
    }

    private void AddDebuff(GameObject target)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null && dealer != null)
        {
            Debug.Log(damageable.Status != dealer.Status);
            Debug.Log(typeDebuff);
        }
        if (damageable != null && dealer != null && damageable.Status != dealer.Status && typeDebuff != null)
        {
            if (target.GetComponent(typeDebuff.GetClass()))
            {
                IDebuff d = (IDebuff)target.GetComponent(typeDebuff.GetClass());
                if (d != null) d.AddStack();
                return;
            }
            target.AddComponent(typeDebuff.GetClass());
        }
    }
}
