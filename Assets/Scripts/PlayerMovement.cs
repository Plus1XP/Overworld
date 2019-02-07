using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState CurrentState;

    public float PlayerSpeed = 4;

    private Rigidbody2D myRigidbody;
    private Vector3 playerMovement;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        CurrentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && CurrentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (CurrentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
	}

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        CurrentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        CurrentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (playerMovement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("playerMovementX", playerMovement.x);
            animator.SetFloat("playerMovementY", playerMovement.y);
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + playerMovement.normalized * PlayerSpeed * Time.deltaTime);
    }
}
