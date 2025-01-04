using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpForce = 10f; //Height that we are going to jump

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;


    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "change")
        {
            SetRandomColor();
            Destroy(collider.gameObject);
            return;
        }

        if (collider.tag != currentColor)
        {
            Debug.Log("Game Over");
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch(index)
        {
            case 0:
                currentColor = "blue";
                sr.color = colorBlue;
                break;

            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;

            case 2:
                currentColor = "purple";
                sr.color = colorPurple;
                break;

            case 3:
                currentColor = "pink";
                sr.color = colorPink;
                break;
        }
    }
}
