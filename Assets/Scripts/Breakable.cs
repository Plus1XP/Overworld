using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Sets bool in blend tree to true, playing the animation
    public void Smash()
    {
        animator.SetBool("isSmashed", true);
        StartCoroutine(BreakCo());
    }

    // Coroutine performs a delay then deactivates (hides) the game object
    // IEnumerator runs in parallel to other processes & for a specified wait time
    IEnumerator BreakCo()
    {
        // Wait .3 secs (for animation to finish) then make the object inactive (hidden) so it isnt destroyed mid animation
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}

/*
 * To keep your classes clean I would break out the breakCO into it's own class, 
 * which simply exposes a method taking in a float which will destroy the object after a set time. 
 * Then you can add it to multiple game objects and re-use this.﻿
 */
