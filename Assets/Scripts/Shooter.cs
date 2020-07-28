using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ValueStat fireRateValue;
    public ValueStat numOfGunsValue;
    public ValueStat distanceBetweenGunsValue;
    public ValueStat angleBetweenGunsValue;
    public ValueStat angleBetweenGunsRandomValue;
    public bool setMoveForward = true;
    public ValueStat forwardOffsetValue;
    public ValueStat angleOffsetValue;
    public ValueStat angleOffsetRandomValue;
    public bool autoShooting = false;
    public GameObject projectile;
    private GameObject lastProjectile;
    private Vector2 moveVector;
    private float lastShootTime = 0;
    public ValueStat chanceToShootAllValue;
    public ValueStat chanceToShootEveryValue;

    private TriggerActivator triggerActivator; 

    void Start()
    {
        triggerActivator = gameObject.GetComponent<TriggerActivator>();
        if (autoShooting)
        {
            InvokeRepeating("AutoShoot", 0f, fireRateValue.GetStatValue());
        } 
    }

    void Update()
    {

    }

    public void Shoot(float angle, bool must = false, Transform parent = null)
    {
        if (Time.time - lastShootTime > fireRateValue.GetStatValue() || must)
        {
            if(Random.value < chanceToShootAllValue.GetStatValue())
            {
                float angleOffsetRandomCurrent = Random.Range(-angleOffsetRandomValue.GetStatValue(), angleOffsetRandomValue.GetStatValue());
                for (int i = 0; i < numOfGunsValue.GetStatValue(); i++)
                {
                    if(Random.value < chanceToShootEveryValue.GetStatValue())
                    {
                        lastProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                        lastProjectile.transform.Rotate(new Vector3(0, 0, angle + ((angleBetweenGunsValue.GetStatValue() * (numOfGunsValue.GetStatValue()-1)) / 2) - angleBetweenGunsValue.GetStatValue() * i + angleOffsetValue.GetStatValue() + Random.Range(-angleBetweenGunsRandomValue.GetStatValue(), angleBetweenGunsRandomValue.GetStatValue()) + angleOffsetRandomCurrent));
                        lastProjectile.transform.Translate(-(distanceBetweenGunsValue.GetStatValue() * (numOfGunsValue.GetStatValue() - 1)) / 2 + i * distanceBetweenGunsValue.GetStatValue(), forwardOffsetValue.GetStatValue(), 0);
                        lastProjectile.SetActive(true);
                        if (setMoveForward)
                        {
                            moveVector = (lastProjectile.transform.TransformPoint(Vector2.up) - lastProjectile.transform.position).normalized;
                            if (lastProjectile.GetComponent<Move>()) lastProjectile.GetComponent<Move>().SetMove(moveVector);
                        }
                        if(parent)
                        {
                            lastProjectile.transform.parent = parent;
                        }
                        if (triggerActivator != null) triggerActivator.ActivateTrigger(EventType.Shoot);
                    }
                }
            }
            lastShootTime = Time.time;
        }

    }

    public void Shoot(Vector2 vector, bool must = false)
    {
        Shoot(Vector2.SignedAngle(Vector2.up, vector), must);
    }

    private void AutoShoot()
    {
        Shoot(transform.TransformPoint(Vector2.up) - transform.position, true);
    }
}
