using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour
{
    public float velocity = 10;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    private float defaultGravity;
    private Vector2 direccion;
    private bool tieneNube = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultGravity = rigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        direccion = new Vector2(x, y);
        Run();
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);

        if (Input.GetKey(KeyCode.UpArrow) && tieneNube)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, velocity);
        }
        if (Input.GetKey(KeyCode.DownArrow) && tieneNube)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -velocity);
        }
    }

    private void Run()
    {
        rigidbody.velocity = new Vector2(direccion.x * velocity, rigidbody.velocity.y);
        spriteRenderer.flipX = direccion.x < 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Nube")
        {
            //Destroy(other.gameObject);
            rigidbody.gravityScale = 0;
            tieneNube = true;
        }
    }

    //Cae al suelo ya no vuela a menos que vuelva a agarrar la nube 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Square")
        {
            rigidbody.gravityScale = defaultGravity;
            tieneNube = false;
        }
    }    
}
