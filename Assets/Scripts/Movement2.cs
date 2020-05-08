using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float moveSpeed = 20f;
    int direction = 0;
    public bool isGround = false;
    public Animator animator2;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad6))
            direction = 1;
        

        else if (Input.GetKey(KeyCode.Keypad4))
            direction = -1;
        
        else
            direction = 0;

        animator2.SetFloat("moveSpeed", Mathf.Abs(direction));
        Vector3 movement = new Vector3(direction*moveSpeed, 0f, 0f);
        transform.position += (movement * Time.deltaTime)/4;
        
        Jump();
        Kick();

        if (isGround == false)
            animator2.SetBool("isJumping", true);

        else
            animator2.SetBool("isJumping", false);

    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            animator2.SetBool("isKicking", true);
            Invoke("StopKick", 0.15f);
        }
    }

    void StopKick()
    {
        animator2.SetBool("isKicking", false);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8) && isGround == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                animator2.SetBool("isKicking", true);
                Invoke("StopKick", 0.15f);
            }

        }
    }


}
