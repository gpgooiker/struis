﻿using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	[SerializeField] public GameObject cactusPrefab;
	private int minHorizontal = -4;
	private int maxHorizontal = 4;
	private GameObject cactus;


	IEnumerator SeedRandom ()
	{
		yield return new WaitForSeconds (Random.Range (0, 100));
	}

	void SpawnObstacle ()
	{
		cactus = Instantiate (cactusPrefab) as GameObject;
		cactus.transform.position = new Vector3 (Random.Range (minHorizontal, maxHorizontal), 14.63f, 0);
		//make child of plane or spawn empty
	}

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		StartCoroutine (SeedRandom ());
		SpawnObstacle ();
	}
}