using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torque = 35F;
    [SerializeField] float boostSpeed = 75F;
    [SerializeField] float baseSpeed = 50F;

    Rigidbody2D rb2D;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        Move();
        EndGame();
    }

    void Move()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    void EndGame()
    {
        // Quits application if user hits escape
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torque);
        }
    }
}
