using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // We want to set it to kinematic in order to move it
    public Rigidbody2D rb;

    // We want to see wether we are interacting with the ball or not

    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {

        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
    }

}
