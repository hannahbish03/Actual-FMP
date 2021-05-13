using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    SpriteRenderer anotherSpriteRenderer;
    public int score;
    int collectables;

    SpriteRenderer mySpriteRenderer;

    float mx;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        score = 0;
    }


    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();

        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.x < 0)
            if ( mySpriteRenderer != null)
            {
                  mySpriteRenderer.flipX = true;
            }



        if (input.x > 0)
        {
            if ( mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = false;
            }

        }
    }

     void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;

        GetComponent<Animator>().SetBool("Jumping", !IsGrounded());


      
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 1.4f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        
        return false; 
    }


    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Winner")
        {
            Debug.Log("works");
            SceneManager.LoadScene("EndScene");
        }

        

    }

        

        }








    



