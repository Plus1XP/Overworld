﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePosition;

    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        // Find the location, scale, rotation & position of the object tagged with "Player"
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckDistance();
	}

    void CheckDistance()
    {
        // Finds the distance from the player to the log
        if (Vector3.Distance(target.position, transform.position) <= ChaseRadius && Vector2.Distance(target.position, transform.position) > AttackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
        }
    }
}