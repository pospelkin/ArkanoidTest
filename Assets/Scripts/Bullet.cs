using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public bool inPlay;
    public Transform plato;
    public float speed;

    public float thrust;

    public Transform box;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        Speed();

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

    

    public void Speed()
    {
        if (GameBehavior.instance.Score == 10)
        {
            thrust = speed * 20;

            //rb2d.AddForce(transform.up * thrust);
            //rb2d.AddRelativeForce(Vector3.forvard * thrust);
            rb2d.AddRelativeForce(transform.forward * thrust);



            //rb2d.AddForce(Vector2.positiveInfinity * thrust);
            //rb2d.velocity = new Vector2(0f, 1f) * thrust;
            //speed = 300;
            Debug.Log("33333333");

        }
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("box"))
        {
            Debug.Log("5555");
        }

        if (other.CompareTag("bottom"))
        {
            rb2d.velocity = Vector2.zero;
            inPlay = false;
        }


    }

    




}

