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
    [SerializeField] AudioSource audio;
    bool activCharge = false;
    [SerializeField] bool playerCharge = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activCharge && Input.GetMouseButton(1) && playerCharge)
        {
            StartCharge();
        }
    }

    public void StartCharge()
    {
        StartCoroutine("ChargeHero");
        if (audio != null) audio.Play();
    }

    IEnumerator ChargeHero()
    {
        activCharge = true;
        moveComponent.speedValue.AddIncrease(speedMultiplecator);
        lifeComponent.Immortal = true;
        yield return new WaitForSeconds(time);
        moveComponent.speedValue.AddIncrease(-speedMultiplecator);
        lifeComponent.Immortal = false;
        yield return new WaitForSeconds(timeReloaded);
        activCharge = false;
    }
}
