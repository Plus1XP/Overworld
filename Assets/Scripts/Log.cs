using System.Collections;
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
        CurrentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();

        // Find the location, scale, rotation & position of the object tagged with "Player"
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Fixed Update is called on the phsyics calls
	void FixedUpdate ()
    {
        CheckDistance();
	}

    void CheckDistance()
    {
        // Finds the distance from the player to the log
        if (Vector3.Distance(target.position, transform.position) <= ChaseRadius && Vector2.Distance(target.position, transform.position) > AttackRadius)
        {
            // Stops the enemy from walking in the stagger state
            if (CurrentState == EnemyState.idle || CurrentState == EnemyState.walk && CurrentState != EnemyState.stagger)
            {
                // If the distance is within the range it should be the enemy will walk forward
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);

                // If log is in the range of movement the state will change to walk
                changeState(EnemyState.walk);
            }
        }
    }

    private void changeState(EnemyState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
        }
    }
}
