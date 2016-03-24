using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	private bool facingRight = false;
	public float speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (!facingRight)
			{
				flip();
			}
			//move right
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (facingRight)
			{
				flip();
			}
			//move left
		}
	}

	void flip()
	{
		facingRight = !facingRight;

		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
