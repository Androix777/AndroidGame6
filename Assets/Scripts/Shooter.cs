using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public float fireRate =0.5f;
    public int numOfGuns = 1;
    public float distanceBetweenGuns;
    public float angleBetweenGuns;
    public float angleBetweenGunsRandom = 0;
    public bool setMoveForward = true;
    public float forwardOffset = 0;
    public float angleOffset = 0;
    public float angleOffsetRandom = 0;
    public bool autoShooting = false;
    public GameObject projectile;
    private GameObject lastProjectile;
    private Vector2 moveVector;
    private float lastShootTime = 0;
    public float chanceToShootAll = 1;
    public float chanceToShootEvery = 1;

    void Start()
    {
        if (autoShooting)
        {
            InvokeRepeating("AutoShoot", 0f, fireRate);
        }
    }

    void Update()
    {

    }

    public void Shoot(float angle, bool must = false, Transform parent = null)
    {
        if (Time.time - lastShootTime > fireRate || must)
        {
            if(Random.value < chanceToShootAll)
            {
                float angleOffsetRandomCurrent = Random.Range(-angleOffsetRandom, angleOffsetRandom);
                for (int i = 0; i < numOfGuns; i++)
                {
                    if(Random.value < chanceToShootEvery)
                    {
                        lastProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                        lastProjectile.transform.Rotate(new Vector3(0, 0, angle + ((angleBetweenGuns * (numOfGuns-1)) / 2) - angleBetweenGuns * i + angleOffset + Random.Range(-angleBetweenGunsRandom, angleBetweenGunsRandom) + angleOffsetRandomCurrent));
                        lastProjectile.transform.Translate(-(distanceBetweenGuns * (numOfGuns - 1)) / 2 + i * distanceBetweenGuns, forwardOffset, 0);
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
