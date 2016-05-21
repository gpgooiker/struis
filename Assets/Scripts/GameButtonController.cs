using UnityEngine;
using System.Collections;
using System;

public class GameButtonController : MonoBehaviour {

	public bool IsHitting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
//			if (Input.mousePosition.x < 0.5 * Screen.width) {
//				IsHittingLeft = true;
//			} else {
//				IsHittingRight = true;
//			}
			IsHitting = true;
			StartCoroutine (stopHitting ());
		}
	}
		
	public void OnPlayerClickRight(){
		IsHitting = true;

		StartCoroutine (stopHitting ());
	}

	// Coroutines use IEnumerators to do 'async' work. On the 'yield' keyword, coroutines 
	// give back control again and let Unity continue to the next frame
	private IEnumerator stopHitting ()
	{
		yield return new WaitForSeconds (1.0f);

		IsHitting = false;
	}
}
