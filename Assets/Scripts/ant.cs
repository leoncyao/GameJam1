﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : MonoBehaviour
{
    public static float speed = 2;
    public static Vector3 target = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    // NEed ant to be able to kill you

    
    private bool has_launched;
    private Rigidbody rb;

    public static int player_health = 3;

    void Start()
    {
        has_launched = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision col) {
        //print(col.collider.gameObject.tag);
        if (col.collider.gameObject.tag == "bullet") 
        {
            Destroy(gameObject);
        }
    }

   
    void Update()
    {
        if (transform.position != target) {
            transform.LookAt(target);
            if (transform.position.z < 10) {
                
                if (!has_launched)
                {
                    //print("has launched");
                    rb.velocity = 0.5f * (-transform.position + new Vector3(0,3.5f,0));
                    has_launched = true;



                    
                }
                if (transform.position.z < 0)
                {
                    player_health -= 1;

                    print(player_health);
                    if (player_health == 0)
                    {
                        Application.Quit();
                        print("quitting");
                    }
                    Destroy(gameObject);
                }

            }

            else {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }
                
        }
    }
}
