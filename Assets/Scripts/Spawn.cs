using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public float spawnRate = 1.0F;
    private float nextSpawn = 0.0F;
    public GameObject star;
    public float speed = 0.0f;
    private float[] xSpawnCoord = new float[5] {-2.666f, -1.333f, 0f, 1.333f, 2.666f};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextSpawn)
		{
			nextSpawn += spawnRate;
			//Spawn stars
			//...
			for (int i = 0; i < 5; i++)
			{
				GameObject clone = (GameObject) Instantiate(star, new Vector3(xSpawnCoord[i], 3), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1 * speed, 0);
            }
		}
	}
}
