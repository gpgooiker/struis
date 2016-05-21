using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

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

		Quaternion referenceRotation = Quaternion.identity;
		Quaternion deviceRotation = DeviceRotation.Get();
		Quaternion eliminationOfXY = Quaternion.Inverse(
			Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
				deviceRotation * Vector3.forward)
		);
		Quaternion rotationZ = eliminationOfXY * deviceRotation;
		angleAroundX = rotationZ.eulerAngles.z;

		Debug.Log ("Angle around X" + angleAroundX);

		movementController.WorldSpeed = Sensibility * angleAroundX;

	}
}
