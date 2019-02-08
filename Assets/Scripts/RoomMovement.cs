using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMovement : MonoBehaviour
{
    public Vector3 CameraChange;
    public Vector3 PlayerChange;
    public bool isPlaceNameActive;
    public string PlaceName;
    public GameObject TextBox;
    public Text PlaceText;

    private CameraMovement cameraMovement;

	// Use this for initialization
	void Start ()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Sets camera bounds for new area via x, y axis change.
            cameraMovement.MinCameraPosition += CameraChange;
            cameraMovement.MaxCameraPosition += CameraChange;
            collision.transform.position += PlayerChange;

            // Show place name on entering new area if bool is true
            if (isPlaceNameActive)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    // Coroutine activates place name text then deactivates (hide) it after 4 secs
    // IEnumerator runs in parallel to other processes & for a specified wait time
    private IEnumerator placeNameCo()
    {
        // Activate place name text box via bool and set the text
        TextBox.SetActive(true);
        PlaceText.text = PlaceName;

        // Adds fade to text
        PlaceText.GetComponent<Text>().CrossFadeAlpha(0, 3.5f, false);

        // Deactivate (hide) place name text box after waiting 4 secs
        yield return new WaitForSeconds(4f);
        TextBox.SetActive(false);
    }
}
