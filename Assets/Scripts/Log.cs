using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePosition;
    public Animator animator;

    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start ()
    {
        CurrentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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
                changeAnimator(temp - transform.position);
                myRigidbody.MovePosition(temp);                

                // If log is in the range of movement the state will change to walk
                changeState(EnemyState.walk);
                animator.SetBool("isAwake", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > ChaseRadius)
        {
            animator.SetBool("isAwake", false);
        }
    }

    private void setAnimatorFloat(Vector2 setVector2)
    {
        animator.SetFloat("logMovementX", setVector2.x);
        animator.SetFloat("logMovementY", setVector2.y);
    }

    // Check the direction of movement for the log
    private void changeAnimator(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Set animation to walking right
            if (direction.x > 0)
            {
                setAnimatorFloat(Vector2.right);
                //animator.SetFloat("logMovementX", 1);
            }

            // Set animation to walking left
            else if (direction.x < 0)
            {
                setAnimatorFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Set animation to walking up
            if (direction.y > 0)
            {
                setAnimatorFloat(Vector2.up);
            }

            //// Set animation to walking down
            else if (direction.y < 0)
            {
                setAnimatorFloat(Vector2.down);
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
