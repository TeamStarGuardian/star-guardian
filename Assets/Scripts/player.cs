﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	private bool facingRight = false;
	public float speed;
    public float fuel = 5;
    public float maxFuel = 10;
    public int score = 0;
    public GUIText scoreText;
    public Sprite goodStar;
    public Sprite badStar;

    public Rect fuelRect;
    public Texture2D fuelTexture;

    void Start()
    {
        fuel = maxFuel;

        fuelRect = new Rect(Screen.width / 10, Screen.height / 10, Screen.width / 3, Screen.height / 50);
        fuelTexture = new Texture2D(1, 1);
        fuelTexture.SetPixel(0, 0, Color.red);
        fuelTexture.Apply();
    }

    // Update is called once per frame
    void Update ()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (!facingRight)
			{
				flip();
			}
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
        }
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (facingRight)
			{
				flip();
			}
            transform.Translate(Vector2.left * 4f * Time.deltaTime);
        }
<<<<<<< HEAD

        if (transform.position.x <= -3.0f)
        {
            transform.position = new Vector2(-3.0f, transform.position.y);
        }
        else if (transform.position.x >= 3.0f)
        {
            transform.position = new Vector2(3.0f, transform.position.y);
        }
    }
=======
	}
>>>>>>> origin/master

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
<<<<<<< HEAD
        //If the player hits the star
        if (col.gameObject.name == "Star(Clone)")
        {
            //Destroy star
            Destroy(col.gameObject);
            //If the star is a good star
            if (col.gameObject.GetComponent<SpriteRenderer>().sprite ==  goodStar)
            {
                //Add 1 to score
                score = score + 1;
                //Set score to reflect new score
                scoreText.text = "Score: " + score;
                //If the player is not at max fuel, add to his fuel
                if(fuel != maxFuel)
                {
                    fuel++;
                }
            }
            //If the player hits a bad star
            if (col.gameObject.GetComponent<SpriteRenderer>().sprite == badStar)
            {
                //Take away fuel from user
                if(fuel != 0)
                {
                    fuel--;
                }
            }
        }
    }

    void OnGUI()
    {
        float ratio = fuel / maxFuel;
        float rectWidth = ratio * Screen.width / 3;
        fuelRect.width = rectWidth;
        GUI.DrawTexture(fuelRect, fuelTexture);
    }
=======
        Debug.Log("Collision Detected");
        if (col.gameObject.name == "Star(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
>>>>>>> origin/master
}
