using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour
{
    public float spawnRate = 1.0F;
    private float nextSpawn = 0.0F;
    public GameObject background;
    private float xSpawnCoord = -2.666f;
    public float speed = 0.0f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(nextSpawn);
        nextSpawn += spawnRate;
        //Pretty much 60 seconds to complete the level
        transform.Translate(Vector2.down * 2f * Time.deltaTime);
    }
}
