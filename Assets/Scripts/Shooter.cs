using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public float fireRate =0.5f;
    public int numOfGuns = 1;
    public float distanceBetweenGuns;
    public float angleBetweenGuns;
    public bool setMoveForward = true;
    public float forwardOffset = 0;
    public float angleOffset = 0;
    public bool autoShooting = false;
    public GameObject projectile;
    private GameObject lastProjectile;
    private Vector2 moveVector;
    private float lastShootTime = 0;

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

    public void Shoot(float angle, bool must = false)
    {
        if (Time.time - lastShootTime > fireRate || must)
        {
            for (int i = 0; i < numOfGuns; i++)
            {
                lastShootTime = Time.time;
                lastProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                lastProjectile.transform.Rotate(new Vector3(0, 0, angle + ((angleBetweenGuns * (numOfGuns-1)) / 2) - angleBetweenGuns * i + angleOffset));
                lastProjectile.transform.Translate(-(distanceBetweenGuns * (numOfGuns - 1)) / 2 + i * distanceBetweenGuns, forwardOffset, 0);
                lastProjectile.SetActive(true);
                if (setMoveForward)
                {
                    moveVector = (lastProjectile.transform.TransformPoint(Vector2.up) - lastProjectile.transform.position).normalized;
                    lastProjectile.GetComponent<Move>().SetMove(moveVector);
                }
                lastProjectile.transform.parent = gameObject.transform.parent;
            }
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
