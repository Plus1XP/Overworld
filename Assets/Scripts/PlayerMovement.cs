using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 4;

    private Rigidbody2D myRigidbody;
    private Vector3 playerMovement;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
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
