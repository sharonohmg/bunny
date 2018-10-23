using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobControl : MonoBehaviour {

    public Transform originPoint;
    private Vector2 dir = new Vector2(-1, 0);
    public float range;
    public float speed;

    public int hitsNeeded = 8;
    public int hitsTaken;

    public Stats blobStats = new Stats();


    Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        blobStats.SetHealth();
    }
	
	// Update is called once per frame
	void Update () {


        Debug.DrawRay(originPoint.position, dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        if (hit == true){

            if(hit.collider.CompareTag("Ground")){
                Flip();
                speed *= -1;
                dir *= -1;
            }
        }
        if (hit == false || hit.collider.CompareTag("Player")){
            Flip();
            speed *= -1;
            dir *= -1;
        }
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Flip(){
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //number of times
            hitsTaken += 1;
            if (hitsTaken >= hitsNeeded)
                Destroy(gameObject);
        }
    }
    public void DamagePlayer(int damage)
    {
       blobStats.Health -= damage;
    }
}
