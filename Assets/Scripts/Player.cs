using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variáveis de controle do personagem
    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool doubleJump;

    // Variáveis privadas
    private Animator animator;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        playerMove();
        Jump();
    }


    // Controla a movimentação do personagem
    public void playerMove()
    {

        // movimentação com position 
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
        

        if(Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            // euler angles é um vetor que guarda a rotação do objeto
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("run", false);
        }

        // movimentação com translate
        //Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0f);
        //transform.Translate(move * Time.deltaTime * speed);


        // movimentação com rigidbody
        //GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0f);
    }


    // Controla o pulo do personagem
    public void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                animator.SetBool("jump", true);
            } 
            else
            {
                if(doubleJump)
                {
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    // Verifica se o personagem está no chão
    void OnCollisionEnter2D(Collision2D colision)
    {
        if(colision.gameObject.layer == 8)
        {
            isJumping = false;
            animator.SetBool("jump", false);
        }
    }
    // Verifica se o personagem saiu do chão
    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
    }

}
