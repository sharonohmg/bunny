using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float horizontal;
    public float speed = 5.5f;
    public float jump;
    public float jumpForce;
    public bool grounded;
    public bool facingRight = true;
    public LayerMask whatIsGround;
    public float groundRadius;
    public Transform groundPoint;



    Rigidbody2D rb;
    Animator animation;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");


	}
    void FixedUpdate()
    {
        Flip();
        grounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
        Movement();
        Jump();
        animation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animation.SetBool("Grounded", grounded);
        animation.SetFloat("vSpeed", rb.velocity.y);

    }
    void Movement(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void Jump(){
        if(grounded)
        rb.velocity = new Vector2(rb.velocity.x, jump * jumpForce);
    }
    void Flip (){
        if (horizontal < 0 && facingRight == true || horizontal > 0 && facingRight == false) {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
