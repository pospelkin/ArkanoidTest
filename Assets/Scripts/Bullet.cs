using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    public Rigidbody2D rb2d;
    public bool inPlay;
    public Transform plato;
    public float speed;
    public float thrust;

    public GameBehavior gameManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Destroy();

        if (Input.GetMouseButtonDown(0) && !inPlay)
        {
            inPlay = true;
            rb2d.velocity = new Vector2(0f, 1f) * speed;
        }
    }
    void Update()
    {
        if (!inPlay)
        {
            transform.position = plato.position;
        }
    }

    public void Destroy()
    {
        if (GameBehavior.instance.CoundDestroyBlock >= 1)
        {
           
            SpeedUp();

        }
    }

    public void SpeedUp()
    {
        thrust = speed * 10;
        rb2d.AddForce(new Vector2(1, 1).normalized * thrust);

       

    }       


void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            rb2d.velocity = Vector2.zero;
            inPlay = false;
        }
    }
}

