using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	[SerializeField] public GameObject cactusPrefab;
	private int minHorizontal = -4;
	private int maxHorizontal = 4;
	private GameObject cactus;
	private bool justSpawned;
	private GameObject worldObject;

	// Use this for initialization
	void Start ()
	{
		justSpawned = false;
		worldObject = GameObject.Find ("Ground");

	}

	// Update is called once per frame
	void Update ()
	{
		SpawnObstacle ();
	}

	void SpawnObstacle ()
	{
		if (!justSpawned) {
			cactus = Instantiate (cactusPrefab) as GameObject;
			cactus.transform.position = new Vector3 (Random.Range (minHorizontal, maxHorizontal), 14.63f, 0);
			cactus.transform.parent = worldObject.transform;
			justSpawned = true;

			// TODO: make child of plane 

			StartCoroutine (SeedRandom ());
		}
	}

	IEnumerator SeedRandom ()
	{
		yield return new WaitForSeconds (Random.Range (0.2f, 0.6f));

		justSpawned = false;
	}
}
