using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GameButtonController))]

public class CollidingController : MonoBehaviour
{
	public int Score = 0;

	private GameButtonController gameButtonController;
	private int health = 90;
	private const int DAMAGE_VALUE = 30;

	void Start ()
	{
		gameButtonController = gameObject.GetComponent<GameButtonController> ();
	}

	void Update ()
	{
	
	}

	IEnumerator Blink ()
	{
		Color tmp = this.GetComponent<SpriteRenderer> ().color;
		tmp.a = 0.0f;
		this.GetComponent<SpriteRenderer> ().color = tmp;
		yield return new WaitForSeconds (.05f);
		tmp.a = 1.0f;
		this.GetComponent<SpriteRenderer> ().color = tmp;
		yield return new WaitForSeconds (.05f);
		tmp.a = 0.0f;
		this.GetComponent<SpriteRenderer> ().color = tmp;
		yield return new WaitForSeconds (.05f);
		tmp.a = 1.0f;
		this.GetComponent<SpriteRenderer> ().color = tmp;
		print (tmp);
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D (Collider2D other)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Enemy")) {
			if (!gameButtonController.IsHitting) {
				if (health <= 0) {
					Destroy (this.gameObject);
				}

				// You're hit and you didn't defend yourself!
				health -= DAMAGE_VALUE;
				StartCoroutine (Blink ());
				print (health);
			} else {
				Score++;
			}
		}
	}
}
