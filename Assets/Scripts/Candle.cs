using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour
{



	//public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;
	// How long between each spawn.
	// An array of the spawn points this enemy can spawn from.


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		//InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}

	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
			Spawn ();
		}
	}

	void Spawn ()
	{
		
		Candle a = Instantiate (this);
		a.transform.Translate (Vector3.up * 5f, Space.Self);
	}
}
