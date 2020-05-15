using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 20f;
    float horizontalmove = 0f;
    public bool isGround = false;
    public Animator animator;
    int direction;
    public bool isShooting;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
       
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
            direction = 1;

        else if (Input.GetKey(KeyCode.A))
            direction = -1;

        else
            direction = 0;

        horizontalmove = direction * moveSpeed;
        Vector3 movement = new Vector3(horizontalmove, 0f, 0f);
        transform.position += movement * Time.deltaTime;
        animator.SetFloat("moveSpeed", Mathf.Abs(horizontalmove));            
                
        Jump();
        Kick();

        if (isGround == false)
            animator.SetBool("isJumping", true);

        else
            animator.SetBool("isJumping", false);

    }

    void Kick()
    {
        if (Input.GetKeyDown("f"))
        {
            isShooting = true;
            animator.SetBool("isKicking", true);
            Invoke("StopKick", 0.15f);
        }
    }
       
    void StopKick()
    {
        animator.SetBool("isKicking", false);
        isShooting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && isShooting == true) // adicionar a condição de pegar no pé
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(4, 5));
        }

        else if(collision.gameObject.tag == "Ball" && isShooting == false)
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 2));
    }

    void Jump()
    {
        if(Input.GetKeyDown("w") && isGround == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            if (Input.GetKeyDown("f"))
            {
                animator.SetBool("isKicking", true);
                Invoke("StopKick", 0.15f);
                }
            
    }
    }

        
}
