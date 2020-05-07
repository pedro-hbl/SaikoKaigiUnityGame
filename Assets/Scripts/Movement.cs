using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float horizontalmove = 0f;
    public bool isGround = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {        
        horizontalmove = Input.GetAxis("Horizontal") * moveSpeed;
        animator.SetFloat("moveSpeed", Mathf.Abs(horizontalmove));
        Jump();
        Kick();
        Vector3 movement = new Vector3(horizontalmove, 0f, 0f);
        transform.position += movement * Time.deltaTime;

        if (isGround == false)
            animator.SetBool("isJumping", true);

        else
            animator.SetBool("isJumping", false);

    }

    void Kick()
    {
        if (Input.GetKeyDown("f"))
        {
            animator.SetBool("isKicking", true);
            Invoke("StopKick", 0.15f);
        }
    }
       
    void StopKick()
    {
        animator.SetBool("isKicking", false);
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
