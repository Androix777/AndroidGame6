using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRedirector : MonoBehaviour, IDamageable
{
    public IDamageable target;
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
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        target.TakeDamage(damage);
    }
}
