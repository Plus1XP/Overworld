using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMovement : MonoBehaviour
{
    public Vector3 CameraChange;
    public Vector3 PlayerChange;
    public bool NeedText;
    public string PlaceName;
    public GameObject text;
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
            //Sets camera bounds for new area.
            cameraMovement.MinPosition += CameraChange;
            cameraMovement.MaxPosition += CameraChange;
            collision.transform.position += PlayerChange;

            //Show place name on entering new area
            if (NeedText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        PlaceText.text = PlaceName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
