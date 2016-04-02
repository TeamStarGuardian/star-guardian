using UnityEngine;
using System.Collections;

public class star : MonoBehaviour
{
	private bool good;
    public float goodStarFraction;
    public Sprite goodStar;
    public Sprite badStar;

	// Use this for initialization
	void Start ()
	{
		float seed = Random.Range(0.0f, 1.0f);
		if (seed < goodStarFraction)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = goodStar;
			good = true;
		}
		else
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = badStar;
			good = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y < -6f)
		{
			Destroy(gameObject);
		}
	}

}
