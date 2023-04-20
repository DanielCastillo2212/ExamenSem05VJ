using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float velocityX = 0.1f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,20);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    /*
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("trigger");
        Debug.Log(other.gameObject.name);
        Destroy(this.gameObject);
    }
    */
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision de bala");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
