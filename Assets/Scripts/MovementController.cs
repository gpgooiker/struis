using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AccelerometerInput))]

public class MovementController : MonoBehaviour
{
	// Attach to a world object

	public float WorldSpeed;

	private Transform worldTransform;
	private float deltaY;
	private Vector3 newPos;
	private float turnSpeed = 3.0f;
	private Vector3 playerLocation = new Vector3 (0, 1, 0);

	// Use this for initialization
	void Start ()
	{
		worldTransform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float rotation = Input.GetAxis ("Horizontal") * turnSpeed;
		worldTransform.RotateAround (playerLocation, Vector3.forward, rotation);


		deltaY = worldTransform.position.y + WorldSpeed;
		Debug.Log ("DeltaY" + deltaY);
	
		newPos = new Vector3 (worldTransform.position.x, deltaY, worldTransform.position.z);
		worldTransform.position = newPos;


	}
		
}
