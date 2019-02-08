using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Smash method in Breakable is called when player hits the collision box tagged with breakable
        if (collision.CompareTag("Breakable"))
        {
            collision.GetComponent<Breakable>().Smash();
        }
    }
}

/*
 * If the object does not have the pot script on it, you will throw an error and break the game. 
 * Before calling the Smash method you should be checking that the GetComponent<pot> is not null first.
 */
