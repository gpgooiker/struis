using UnityEngine;
using System.Collections;

public class CollidingController : MonoBehaviour {
	private BattleController battleController;
    private int health = 90;
    private const int DAMAGE_VALUE = 30;

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

    IEnumerator Blink()
    {
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.05f);
        tmp.a = 1.0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.05f);
        tmp.a = 0.0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.05f);
        tmp.a = 1.0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        print(tmp);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                //blink
                health -= DAMAGE_VALUE;
                StartCoroutine(Blink());
                print(health);
            }
        }
    }
}
