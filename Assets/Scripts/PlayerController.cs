using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    public GameObject bala;
    public GameObject bala2;
    public GameObject bala3;
    public EnemyCollider enemyCollider;
    public EnemyCollider enemyCollider2;
    public EnemyCollider enemyCollider3;

    // Start is called before the first frame update
    private int currentAnimation = 1;
    public int varVelocity = 5;
    public int BalaDic {get; set;} = 1;

    public bool Muerte = false;
    //public float jumpForce = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;
        var velocityY = rb.velocity.y;

        rb.velocity = new Vector2(0, velocityY);

        
         //Run
        if(Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(varVelocity, velocityY);
            BalaDic = 1;
            Debug.Log(varVelocity);
            sr.flipX = false;
        }
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(-5, velocityY);
            BalaDic = -1;
            sr.flipX = true;
        }
        /*
        //Jump
        if(Input.GetKeyDown(KeyCode.Space)){
            currentAnimation = 3;
            //rb.velocity = new Vector2(5, velocityY);
            rb.AddForce(new Vector2(0, jumpForce));
        }
        */
        //Roll
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 4;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 4;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        //Die
        if(Muerte){

            currentAnimation = 5;
            
        }
        if(enemyCollider.enemyColision){

            currentAnimation = 5;
        }
         if(enemyCollider2.enemyColision){

            currentAnimation = 5;
        }
         if(enemyCollider3.enemyColision){

            currentAnimation = 5;
        }

        if(Input.GetKeyUp(KeyCode.U) && !Muerte) {
         // crear a la bala
         // que objeto
         // en donde debe aparecer
         // que rotacion va a tener?
         var currentPosition = transform.position;
         var position = new Vector3(currentPosition.x + (1*BalaDic), currentPosition.y, 10);
         var balaGO = Instantiate(bala, position, Quaternion.identity);
         var controller = balaGO.GetComponent<BalaController>();
         controller.velocityX = (5*BalaDic);
       }

       if(Input.GetKeyUp(KeyCode.O) && !Muerte) {
         // crear a la bala
         // que objeto
         // en donde debe aparecer
         // que rotacion va a tener?
         var currentPosition2 = transform.position;
         var position2 = new Vector3(currentPosition2.x + (2*BalaDic), currentPosition2.y + 1, 10);
         var balaGO2 = Instantiate(bala2, position2, Quaternion.identity);
         var controller2 = balaGO2.GetComponent<BalaController2>();
         controller2.velocityX = (1*BalaDic);

         var currentPosition3 = transform.position;
         var position3 = new Vector3(currentPosition3.x + (2*BalaDic), currentPosition3.y -1, 10);
         var balaGO3 = Instantiate(bala3, position3, Quaternion.identity);
         var controller3 = balaGO3.GetComponent<BalaController3>();
         controller3.velocityX = (1*BalaDic);

       }

        animator.SetInteger("Estado", currentAnimation);
    }

    private void OnCollisionEnter2D(Collision2D other){
        Muerte = false;
      if (other.gameObject.CompareTag("Enemy")){
          Debug.Log("Muerte");
          //ani.isDead=true;
          //Destroy(this.gameObject);
          //currentAnimation = 5;
          Muerte = true;
      }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que ha entrado en el trigger tiene la etiqueta "Potion", entonces lo hacemos desaparecer
        if (other.gameObject.CompareTag("Enemy"))
        {
            varVelocity+=5;
            //Debug.Log("OnTrigger");
            //other.gameObject.SetActive(false);
            //jumpEnemy = true;
        }
    }
    */
}
