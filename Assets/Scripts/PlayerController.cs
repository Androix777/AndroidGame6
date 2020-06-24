using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Shooter))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Shooter shooter;
    [SerializeField] private Move moveComponent;
    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        moveComponent.SetMove(movement);

        if (Input.GetKey("up"))
        {
            shooter.Shoot(0);
        } else
        if (Input.GetKey("down"))
        {
            shooter.Shoot(180);
        }
        else
        if (Input.GetKey("left"))
        {
            shooter.Shoot(90);
        } else
        if (Input.GetKey("right"))
        {
            shooter.Shoot(270);
        }
    }
}
