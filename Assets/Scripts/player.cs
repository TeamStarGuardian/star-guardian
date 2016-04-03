using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	private bool facingRight = false;
	public float speed;
    public float fuel;
    public float maxFuel = 30;
    public int score = 0;
    public GUIText scoreText;
    public Sprite goodStar;
    public Sprite badStar;

    public Rect fuelRect;
    public Texture2D fuelTexture;

    public AudioClip badStarAudio;
    public AudioClip goodStarAudio;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        fuel = maxFuel;

        fuelRect = new Rect(Screen.width / 4, Screen.height/ 1.2F, Screen.width / 24, Screen.height / 30);
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

        if (transform.position.x <= -3.0f)
        {
            transform.position = new Vector2(-3.0f, transform.position.y);
        }
        else if (transform.position.x >= 3.0f)
        {
            transform.position = new Vector2(3.0f, transform.position.y);
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
        //If the player hits the star
        if (col.gameObject.name == "Star(Clone)")
        {
            //Destroy star
            Destroy(col.gameObject);
            //If the star is a good star
            if (col.gameObject.GetComponent<SpriteRenderer>().sprite ==  goodStar)
            {
                source.PlayOneShot(goodStarAudio, 5);
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
                source.PlayOneShot(badStarAudio, 5);
                //Take away fuel from user
                if (fuel != 0)
                {
                    fuel--;
                }
            }
        }
    }

    //Drawing the fuelgauge
    void OnGUI()
    {
        float ratio = -(fuel / maxFuel);
        float rectHeight = ratio * Screen.height / 2;
        fuelRect.height = rectHeight;
        GUI.DrawTexture(fuelRect, fuelTexture);
    }
}
