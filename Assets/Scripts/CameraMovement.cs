using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float Smoothing = 0.6f;

    public Vector2 MaxPosition;
    public Vector2 MinPosition;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (transform.position != Target.position)
        {
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, MinPosition.x, MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing);
        }
	}
}
