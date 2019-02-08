using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // What the camera is following (gives x, y postion)
    public Transform Target;

    // How quickly the camera move towards target
    public float Smoothing = 0.6f;

    public Vector3 MaxCameraPosition;
    public Vector3 MinCameraPosition;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// LateUpdate is the last thing called in a frame (adjusts after the player has moved)
	void LateUpdate ()
    {
        //Forces camera to follow player.
        if (transform.position != Target.position)
        {
            // Sets target position using the main camera's Z axis instead of the player's
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);

            // Stops camera movement exceeding values of MinCameraPosition & MaxCameraPosition
            targetPosition.x = Mathf.Clamp(targetPosition.x, MinCameraPosition.x, MaxCameraPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinCameraPosition.y, MaxCameraPosition.y);

            // Lerp finds the distance between it and the target and moves a percentage towards it each frame
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing);
        }
	}
}
