using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	// Attach to a player object

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x < 0.5 * Screen.width) {
				Debug.Log ("Hit left!");
			} else {
				Debug.Log ("Hit right!");
			}
		}
	}
}
