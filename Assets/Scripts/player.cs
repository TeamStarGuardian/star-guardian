using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	private bool facingRight = false;
	public float speed;
	public int fuel;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (!facingRight)
			{
				flip();
			}
			transform.Translate(speed, 0, 0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (facingRight)
			{
				flip();
			}
			transform.Translate(-speed, 0, 0);
		}
	}

	//Change direction player sprite is facing
	void flip()
	{
		facingRight = !facingRight;

		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "star")
		{
			
		}
	}
}
