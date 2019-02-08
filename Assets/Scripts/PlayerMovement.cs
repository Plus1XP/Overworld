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

        // Sets player facing down when initialized to avoid all hit boxes being active
        animator.SetFloat("playerMovementX", 0);
        animator.SetFloat("playerMovementY", -1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Reset how much the player has changed position
        playerMovement = Vector3.zero;

        // Get x, y values of movement via the input and assign the values to player movement
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        // Checks that the player is not already attacking and that the Fire1 button is pressed
        if (Input.GetButtonDown("Fire1") && CurrentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }

        // If the player is not attacking (walk state) check if there is a change in player position
        else if (CurrentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
	}

    // Coroutine changes player state & animation incorporating a delay
    // IEnumerator runs in parallel to other processes & for a specified wait time
    private IEnumerator AttackCo()
    {
        // Sets attack bool to true, playing animation & setting player state to attack then waiting for 1 frame
        animator.SetBool("isAttacking", true);
        CurrentState = PlayerState.attack;
        yield return null;

        // Sets attack bool to false then waiting .3 secs (for animation to finish) before changing player state to walk
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.3f);
        CurrentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        // Checks if there is a change in the character position (moving)
        if (playerMovement != Vector3.zero)
        {
            MoveCharacter();

            // Using value from playerMovement input to set animations in blend tree
            animator.SetFloat("playerMovementX", playerMovement.x);
            animator.SetFloat("playerMovementY", playerMovement.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    // This method will allow the character to move with on screen buttons etc. Not just keyboard
    void MoveCharacter()
    {
        // Normalize speed of diagonal movement instead of adding horizonal & vertical
        playerMovement.Normalize();

        // transform.position is the current position of the player in the scene
        // playerMovement is the change of the player position, which is too slow each frame 
        // It is * by playerSpeed variable * the time that has passed since the previous frame
        myRigidbody.MovePosition(transform.position + playerMovement * PlayerSpeed * Time.deltaTime);
    }
}

/*
    For activating hitboxes via code and not animator 
    Make sure to remove the hitbox activation from the animation 

    //create an enum for which way the player is facing 
    public enum PlayerFace 
    {
        Up, 
        Down, 
        Left, 
        Right 
    } 

    // set up a public variable for the PlayerFace 
    public PlayerFace currentFace; 

    // set up references to the hitboxes and attach them in the GUI 
    public GameObject HitBoxDown; 
    public GameObject HitBoxUp;
    public GameObject HitBoxLeft; 
    public GameObject HitBoxRight; 

    // default the face on Start() 
    currentFace = PlayerFace.Down; 

    // update the face in UpdateAnimationAndMove() 
    if player moved if (change != Vector3.zero) 
    { 
        UpdateFace(); 
        MoveCharacter(); 
        ... 
    }

    // update face functions private void UpdateFace() 
    {
        if (change.x > 0) 
        { 
            currentFace = PlayerFace.Right; 
        } 
        else if(change.x < 0) 
        {
            currentFace = PlayerFace.Left; 
        } 
        if (change.y > 0) 
        {
            currentFace = PlayerFace.Up; 
        }
        else if (change.y < 0) 
        { 
            currentFace = PlayerFace.Down; 
        }
    }

    // activate the appropriate hitbox in attach coroutine 
    switch (currentFace) 
    { 
        case PlayerFace.Down: HitBoxDown.SetActive(true); 
        break; 
        case PlayerFace.Up: HitBoxUp.SetActive(true); 
        break; 
        case PlayerFace.Left: HitBoxLeft.SetActive(true); 
        break; 
        case PlayerFace.Right: HitBoxRight.SetActive(true); 
        break; 
    } 

    // after the animation (at the end of the coroutine) turn off the active hitbox (or all) 
    HitBoxDown.SetActive(false); 
    HitBoxUp.SetActive(false); 
    HitBoxLeft.SetActive(false); 
    HitBoxRight.SetActive(false);
*/
