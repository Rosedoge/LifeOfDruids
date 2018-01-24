using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//animation taken from https://www.spriters-resource.com/fullview/41779/
public class PlayerScript : MonoBehaviour {

    #region movement
    bool walking = false, flipped = false;
    bool jumping = false, jumpImpulsed = false;
    int forward = 1;

    Animator myAnimator;
    #endregion

    #region my Parts

    //GameObject gunPort;
    [SerializeField]
        GameObject fireball;
    // GameObject myGun;
    public static PlayerScript instance = null;

    Rigidbody2D myRigid;

    #endregion

    #region vitals
    int health = 100;
    public bool InControl = true;

    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
       // myGun = transform.GetChild(1).gameObject;
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InControl)
        {
            Inpot();

            if (MyFoward > 0 && flipped)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                flipped = false;
                //FlipChildren(false);
            }
            else if (MyFoward < 0 && !flipped)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                flipped = true;
                // FlipChildren(true);
            }
        }

        //Health
        float perc = (float)health / 100;
        if (health <= 0)
        {
            Die();
        }
        else
        {

        }
          
    }



    void Inpot()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            IsWalking = true;
            if (Input.GetKeyDown(KeyCode.A))
            {
                MyFoward = -1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MyFoward = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myAnimator.SetTrigger("Shoot");
        
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
          
            CancelInvoke();
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            IsWalking = false;
        }

        //Jump
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = true;
        }




        Vector3 move = new Vector3(Input.GetAxis("Horizontal")*2, 0, 0);
        transform.position += move * 2.0f * Time.deltaTime;
        if (IsJumping)
        {
            if (!jumpImpulsed)
            {
                jumpImpulsed = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Contains("Floor"))
        {
            jumpImpulsed = false;
            IsJumping = false;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                IsWalking = true;

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Killzone") || other.tag.Contains("Lavafall"))
        {
            myAnimator.SetTrigger("Death");
            myRigid.gravityScale = 0;
            Invoke("Reset", 2f);
        }
    }

    private void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }


    public void ShootFireball()
    {
        GameObject temp = Instantiate(fireball, transform.position, transform.rotation);
       // Debug.Log("Horiz: " + Input.GetAxis("Horizontal"));
       // Debug.Log("Vertical: " + Input.GetAxis("Vertical"));
        temp.GetComponent<FireballScript>().Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //temp.GetComponent<FireballScript>().mospos = Input.mousePosition;
    }



    #region vital functions----------------------------------------------------------------------------------------------------------------------

    public void RegenerateHealth(int value)
    {
        if (health + value <= 100)
            health += value;
        else
            health = 100;
    }

    void Die()
    {

    }

  

    #endregion vital functions



    #region GetSet
    public int MyFoward
    {
        get
        {
            return forward;
        }
        set
        {
            forward = value;
        }


    }
    public bool IsJumping
    {
        get
        {
            return jumping;
        }

        set
        {
            jumping = value;
            IsWalking = false;
        }

    }
    bool IsWalking
    {
        get
        {
            return walking;
        }

        set
        {
            walking = value;
            if (value)
            {
                myAnimator.SetBool("Walking", true);
            }
            else
            {
                myAnimator.SetBool("Walking", false);
            }
        }


    }

    #endregion
}
