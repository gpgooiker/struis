using UnityEngine;
using System.Collections;

public class BattleController: MonoBehaviour {
	// Attach to a player
	public bool IsHittingLeft;
	public bool IsHittingRight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x < 0.5 * Screen.width) {
				IsHittingLeft = true;
			} else {
				IsHittingRight = true;
			}
		}
	}
}
