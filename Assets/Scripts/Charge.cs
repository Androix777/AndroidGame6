using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    [SerializeField] private Move moveComponent;
    [SerializeField] private Life lifeComponent;
    [SerializeField]private float speedMultiplecator = 1;
    [SerializeField] float time;
    [SerializeField] float timeReloaded;
    bool activCharge = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activCharge && Input.GetMouseButton(1))
        {
            StartCoroutine("ChargeHero");
        }
    }

    IEnumerator ChargeHero()
    {
        activCharge = true;
        moveComponent.speed = moveComponent.speed * speedMultiplecator;
        lifeComponent.Immortal = true;
        yield return new WaitForSeconds(time);
        moveComponent.speed = moveComponent.speed / speedMultiplecator;
        lifeComponent.Immortal = false;
        yield return new WaitForSeconds(timeReloaded);
        activCharge = false;
    }
}
