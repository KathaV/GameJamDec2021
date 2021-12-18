using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float playerSpeed = 5f;
    public float jumpSpeed = 30f;
    private bool isJump = false;
    public float gravityScale = 15f;
    public AudioSource jumpSFX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = transform.GetComponent<Rigidbody2D>();
        // default values
        rb.gravityScale = gravityScale;
        //jumpSFX = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Horizontal movement
        if (Input.GetKey("a"))
        {
            player.transform.localPosition += new Vector3(-playerSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey("d"))
        {   
            player.transform.localPosition += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        } 

        // Jump mechanics
        if (isJump == false && Input.GetKey("w"))
        {   
            rb.velocity = Vector2.up * jumpSpeed;
            isJump = true;
            jumpSFX.Play();
        }
    }

    // detecting whether player is grounded
    // maybe should be moved to player attribute?????????????
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "HidingPlace"))
        {
            float normal = collision.contacts[0].normal.y;
            Debug.Log(normal);
            if (normal > 0.99)
            {
                //collision was from below
                isJump = false;
            }
        }
    }

}
