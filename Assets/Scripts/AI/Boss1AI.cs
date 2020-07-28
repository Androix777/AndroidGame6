using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    public Shooter shooter;
    private int now = -1, maximumAttacks = 8;
    private bool inProgress = false;
    void Start()
    {

    }

    void Update()
    {
        Attack();
    }   

    void Attack()
    {
        if(!inProgress)
        {
            inProgress = true;
            now++;
            switch(now % maximumAttacks)
            {
                case 0:
                    StartCoroutine(Attack1());
                    break;
                case 1:
                    StartCoroutine(Waiting(1));
                    break;
                case 2:
                    StartCoroutine(Attack2());
                    break;
                case 3:
                    StartCoroutine(Waiting(1));
                    break;
                case 4:
                    StartCoroutine(Attack3());
                    break;
                case 5:
                    StartCoroutine(Waiting(1));
                    break;
                case 6:
                    StartCoroutine(Attack4());
                    break;
                case 7:
                    StartCoroutine(Waiting(1));
                    break;
            }
        }
    }

    IEnumerator Waiting(float time)
    {
        yield return new WaitForSeconds(time);
        inProgress = false;
    }

    IEnumerator Attack1()
    {
        shooter.numOfGunsValue.SetValue(24);
        shooter.angleBetweenGunsValue.SetValue(15);
        shooter.angleOffsetRandomValue.SetValue(0);
        for (int i = 0; i<10; i++)
        {
            shooter.Shoot(0, true);
            shooter.angleOffsetValue.AddValue(5);
            yield return new WaitForSeconds(0.5f);
        }
        inProgress = false;
    }

    IEnumerator Attack2()
    {
        shooter.numOfGunsValue.SetValue(1);
        shooter.angleBetweenGunsValue.SetValue(0);
        shooter.angleOffsetRandomValue.SetValue(0);
        float n = 0;
        for (int i = 0; i<180; i++)
        {
            shooter.Shoot(n, true);
            shooter.Shoot(180 + n, true);
            n+=2f;
            yield return new WaitForSeconds(0.04f);
        }
        inProgress = false;
    }

    IEnumerator Attack3()
    {
        shooter.numOfGunsValue.SetValue(10);
        shooter.angleBetweenGunsValue.SetValue(2);
        shooter.angleOffsetRandomValue.SetValue(180);
        for (int i = 0; i<30; i++)
        {
            shooter.Shoot(0, true);
            yield return new WaitForSeconds(0.15f);
        }
        inProgress = false;
    }

    IEnumerator Attack4()
    {
        shooter.numOfGunsValue.SetValue(1);
        shooter.angleBetweenGunsValue.SetValue(0);
        shooter.angleOffsetRandomValue.SetValue(180);
        for (int i = 0; i<500; i++)
        {
            shooter.Shoot(0, true);
            yield return new WaitForSeconds(0.01f);
        }
        inProgress = false;
    }
}
