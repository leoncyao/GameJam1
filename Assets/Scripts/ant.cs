using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : MonoBehaviour
{
    public static float speed = 1;
    public static Vector3 target = new Vector3(0, 0, 0);
    // Start is called before the first frame update

    
    private bool has_launched;
    private Rigidbody rb;

    void Start()
    {
        has_launched = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target) {
            transform.LookAt(target);
            if (transform.position.z < 10) {
                if (!has_launched)
                {

                    rb.velocity = 0.5f * (-transform.position + new Vector3(0,3.5f,0));
                    has_launched = true;
                }
                
            }

            else {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }
                
        }
    }
}
