using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
public float speed = 30f;
public string axis;

    void FixedUpdate()
    {
        float input = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, input) * speed;


    }
}
