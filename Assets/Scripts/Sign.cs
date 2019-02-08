using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text DiaglogueText;
    public string Dialogue;
    public bool isPlayerInRange;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // To interact with a sign the player must be in range and pressing the "Jump" action key
        if (Input.GetButtonDown("Jump") && isPlayerInRange)
        {
            // If dialogue box is active this will deactivate it (hidden)
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }

            // If dialogue is not active (hidden) this will make it active and set the text via unity
            else
            {
                DialogueBox.SetActive(true);
                DiaglogueText.text = Dialogue;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if player is in range (inside the collision box) and sets the bool to true
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Checks if player is out of range and deactivates sign text
            isPlayerInRange = false;
            DialogueBox.SetActive(false);
        }
    }
}
