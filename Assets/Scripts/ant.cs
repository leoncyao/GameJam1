using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : MonoBehaviour
{
    public static float speed = 1;
    public static Vector3 target = new Vector3(0, 0, 0);
    // Start is called before the first frame update


    private bool has_launched;
    private RigidBody rb;

    void Start()
    {
        has_launched = false;
        rb = GetComponent<RigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target) { 
            
            if (transform.position > -10) {
                rb.velocity = -transform.position;
            }

            else {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }
                // try to animate jump sequence using rb, otherwise keep crawling
            //launch if set rigidbody .add velocity to something
        }
    }
}
