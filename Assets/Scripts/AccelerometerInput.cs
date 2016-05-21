using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{
	// Attach to a world object

	public float Sensibility = 0.4f;

	private MovementController movementController;
	private Transform worldTransform;
	private float angleAroundX;

	// Use this for initialization
	void Start ()
	{
		movementController = gameObject.GetComponent<MovementController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		angleAroundX = Input.gyro.attitude.x;
		Debug.Log (angleAroundX);

		movementController.WorldSpeed = Sensibility * angleAroundX;

	}
}
