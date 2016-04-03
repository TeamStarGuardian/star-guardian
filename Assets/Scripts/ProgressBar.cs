using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public float spawnRate = 1.0F;
    private float nextSpawn = 0.0F;

    // Use this for initialization
    void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        //Progresses the progression person across the progression bar from left to right
        if (Time.time > nextSpawn)
        {
            Debug.Log(nextSpawn);
            nextSpawn += spawnRate;
            //Pretty much 60 seconds to complete the level
            transform.Translate(Vector2.right * 9f * Time.deltaTime);
        }
    }
}
