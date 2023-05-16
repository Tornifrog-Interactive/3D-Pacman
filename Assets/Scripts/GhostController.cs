using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GhostController : MonoBehaviour
{
	public float speed = 1f;
	public float directionChangeInterval = 1f;
	public float maxHeadingChange = 60f;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	void Awake ()
	{
		controller = GetComponent<CharacterController>();

		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}

	void Update ()
	{
        // Moves ghost
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
	}


	// Repeatedly calculates a new direction to move towards.
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	// Calculates a new direction to move towards.
	void NewHeadingRoutine ()
	{
		var floor = transform.eulerAngles.y - maxHeadingChange;
		var ceil  = transform.eulerAngles.y + maxHeadingChange;
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0f, heading, 0f);
	}

}