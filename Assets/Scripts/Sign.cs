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
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInRange)
        {
            if(DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);
            }
            else
            {
                DialogueBox.SetActive(true);
                DiaglogueText.text = Dialogue;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            DialogueBox.SetActive(false);
        }
    }
}
