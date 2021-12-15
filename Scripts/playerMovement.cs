using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    //private bool grounded;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    


    // Start is called before the first frame update
    void Start()
    {
        //Brab references 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        //StartCoroutine("DisableScript");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        

        if (Input.GetKey(KeyCode.Space))
            Jump();

        //flipping the player image right to left
        if (horizontalInput > 0.01f) //moving to the right
            transform.localScale = new Vector3(5, 5, 5);
        else if (horizontalInput < -0.01f) //moving to the right
            transform.localScale = new Vector3(-5, 5, 5);

        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //wall jump cooldown
        if (wallJumpCooldown > 0.2f)
        {
            

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;
            
            if (Input.GetKey(KeyCode.Space) && isGrounded())
                Jump();

        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
            //grounded = false;
        }
        else if (onWall() && !isGrounded())
        {
            //if (horizontalInput == 0)
            //{
                //body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                //transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //} else 
                //body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "ground")
            //grounded = true;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public void getStunned()
    {
        GetComponent<playerMovement>().enabled = false;

        anim.SetTrigger("stunned");

        //yield return new WaitForSeconds(3f);

        GetComponent<playerMovement>().enabled = true;
    }

    //public IEnumerator DisableScript()
    //{
    //    GetComponent<playerMovement>().enabled = false;

    //    yield return new WaitForSeconds(3f);

    //    GetComponent<playerMovement>().enabled = false;
//  }

}
