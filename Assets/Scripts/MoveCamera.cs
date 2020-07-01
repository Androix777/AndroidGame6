using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] new GameObject camera;
    [SerializeField] GameObject hero;
    [SerializeField] float range;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hero != null && camera != null)
        {
            float distance = Vector2.Distance(hero.transform.position,camera.transform.position);
            if (distance > range)
            {
                Vector2 toHero = (hero.transform.position - camera.transform.position) * (distance / range - 1f);
                camera.transform.position += new Vector3(toHero.x,toHero.y,0);
            }
        }
    }
}
