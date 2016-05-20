using UnityEngine;
using System.Collections;

// Attach to a player that also has a colliding controller attached
[RequireComponent (typeof(CollidingController))]

public class BattleController: MonoBehaviour {

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
			StartCoroutine (stopHitting ());
		}

	}

	// Coroutines use IEnumerators to do 'async' work. On the 'yield' keyword, coroutines 
	// give back control again and let Unity continue to the next frame
	private IEnumerator stopHitting ()
	{
		yield return new WaitForSeconds (1);

		IsHittingLeft = false;
		IsHittingRight = false;
	}
}
