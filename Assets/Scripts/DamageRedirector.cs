using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRedirector : MonoBehaviour, IDamageable
{
    public GameObject target;
    private IDamageable damageTarget;

    [SerializeField] private Status _status = Status.Enemy;
    public Status Status
    {
        get
        { 
            return _status; 
        }
        set
        { 
            _status = value; 
        }
    }
    void Start()
    {
        if (target.GetComponent<IDamageable>() != null)
        {
            damageTarget = target.GetComponent<IDamageable>();
        }
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (damageTarget != null)
        {
            damageTarget.TakeDamage(damage);
        }
        
    }
}

