using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Players");
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Players")
        {

        }

    }
}
