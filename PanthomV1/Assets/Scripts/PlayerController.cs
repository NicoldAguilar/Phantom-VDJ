using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5, jumpForce = 3;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    bool saltos;

    //Constantes para los estados de las animaciones 
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CORRIENDO = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ha iniciado el juego");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        ChangeAnimation(ANIMATION_QUIETO);

        //rb.velocity.x:
        //rb.velocity.y:
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(ANIMATION_CORRIENDO);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(ANIMATION_CORRIENDO);
        }
        //Añadir fuerza para el salto
        if (Input.GetKeyUp(KeyCode.Space) && saltos)
        {
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse); //método recomendado
            saltos = false; //salta una vez
        }
    }

    //Guarda contra quien colisona el personaje
    void OnCollisionEnter2D(Collision2D other)
    {
        saltos = true;
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemigo")
        {
            Debug.Log("Estas muerto");
        }
    }

    private void ChangeAnimation(int animation)
    {
        //Estado en 1 = pasa de iddle a correr
        //Estado en 0 = De correr a iddle
        animator.SetInteger("Estado", animation);
    }

}
