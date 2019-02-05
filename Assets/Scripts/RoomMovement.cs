using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public Vector3 CameraChange;
    public Vector3 PlayerChange;

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
            cameraMovement.MinPosition += CameraChange;
            cameraMovement.MaxPosition += CameraChange;
            collision.transform.position += PlayerChange;
        }
    }
}
