using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	// Attach to a world object

	public float WorldSpeed = 0.0f;

	private Transform worldTransform;
	private float deltaY;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
		worldTransform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		deltaY = worldTransform.position.y + WorldSpeed;
		newPos = new Vector3(worldTransform.position.x, deltaY, worldTransform.position.z);
		worldTransform.position = newPos;

		// Sturen:
		// worldTransform.rotation.z += 2
	}
		
}
