using UnityEngine;
using System.Collections;

public class CollidingController : MonoBehaviour {
	private BattleController battleController;

	// Use this for initialization
	void Start () {
		battleController = gameObject.GetComponent<BattleController> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Am I colliding?
		if (battleController.IsHittingLeft) {
			Debug.Log ("Handling a hit while colliding into something");
		}
	
	}
}
