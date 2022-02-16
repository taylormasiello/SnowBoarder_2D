using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float torqueAmout = 1F;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmout);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmout);
        }
    }
}
