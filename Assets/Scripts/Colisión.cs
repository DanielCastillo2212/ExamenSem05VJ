using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisión : MonoBehaviour
{
    public FootController footController;
    public LateralesController lateralesController;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float jumpForce = 200f;
    private bool canJump=false;
    private bool jumpEnemy=false;
    private int currentAnimation = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;
        /*
        var velocityY = rb.velocity.y;

        rb.velocity = new Vector2(0, velocityY);
        */

        bool goJump = (footController.canJump && !lateralesController.nextJump()) || (footController.canJump && lateralesController.nextJump()) || (!footController.canJump && lateralesController.nextJump());

        if(Input.GetKeyDown(KeyCode.Space) && goJump){
            currentAnimation = 3;
            //rb.velocity = new Vector2(5, velocityY);
            //rb.AddForce(new Vector2(0, jumpForce));
           this.impulseAdd(this.jumpForce);
            
        }
        /*
            //Run
        if(Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        
          */
        
    }

    private void impulseAdd(float jumpForce){
        rb.AddForce(new Vector2(0, jumpForce));
        footController.canJump = false;
        lateralesController.validationJump();
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que ha entrado en el trigger tiene la etiqueta "Potion", entonces lo hacemos desaparecer
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("OnTrigger");
            other.gameObject.SetActive(false);
            jumpEnemy = true;
        }
    }
    */
}
