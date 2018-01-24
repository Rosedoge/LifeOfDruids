using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {
    /// <summary>
    /// These are all right facing fireballs, so they'll need to be flipped with the player as well.
    /// </summary>
    public List<Sprite> Fireballs;
    public Vector2 Direction = new Vector2(0, 0);
    Vector2 direction;
    public bool flipped = false;
    public Vector2 mospos;
    SpriteRenderer myrender;
	// Use this for initialization
	void Start () {
        mospos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        myrender = GetComponent<SpriteRenderer>();
        Vector2 direction = mospos - (Vector2)transform.position;
        direction.Normalize();
        Debug.Log("Direction is " + direction);
        if (direction.x < 0)
        {
            if(direction.y < 0)
            {
                Flip();
                myrender.sprite = Fireballs[3];
            }
            else if (direction.y == 0)
            {
                Flip();
                myrender.sprite = Fireballs[2];
            }
            else if (direction.y > 0)
            {
                Flip();
                myrender.sprite = Fireballs[1];
            }

        }
        if (direction.x > 0)
        {
            if (direction.y < 0)
            {
                myrender.sprite = Fireballs[3];
            }
            else if (direction.y == 0)
            {

                myrender.sprite = Fireballs[2];
            }
            else if (direction.y > 0)
            {

                myrender.sprite = Fireballs[1];
            }
        }
        if (direction.x == 0)
        {
            if (direction.y < 0)
            {
                myrender.sprite = Fireballs[4];
            }
            else if (direction.y == 0)
            {
               if(PlayerScript.instance.MyFoward <= 0)
                {
                    Flip();
                    direction = new Vector2(-1, 0);
                    myrender.sprite = Fireballs[2];
                }
                else
                {
                    direction = new Vector2(1, 0);
                    myrender.sprite = Fireballs[2];
                }
            }
            else if (direction.y > 0 )
            {
                myrender.sprite = Fireballs[0];
            }

        }

        GetComponent<Rigidbody2D>().velocity = direction * 10;

    }
	

    public void Flip()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        flipped = true;
    }
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
