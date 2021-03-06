﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 10; i < 100; i += 10)
        //{
        //    InvokeRepeating("Spawn", i, i);
        //}

        float time_scale = 1f;
        InvokeRepeating("Spawn", 0, 10 * time_scale);
        InvokeRepeating("Spawn", 5 * time_scale, 5 * time_scale);
        InvokeRepeating("Spawn", 10 * time_scale, 2.5f * time_scale);
        //Spawn();
        //Spawn();


        // need to give player hit points
        hp = 3;

    }


    public GameObject bullet_prefab;
    public GameObject ant_prefab;
    // public GameObject spray_prefab;

    public static float bullet_speed = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Acquire mouse positioning

            //Vector3 newTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            //print(newTarget);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f))
            {
                
                GameObject bullet = Instantiate(bullet_prefab);
                bullet.GetComponent<Rigidbody>().velocity = bullet_speed * hit.point;

                //print(hit.transform.position);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right click");
            //spray_prefab.GetComponent<ParticleSystem>().Emit(1);
            // Do spray effect

        }

    }

    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;

    // Use this for initialization
    //void Start()
    //{
    //    // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        

    //}

    void Spawn()
    {
        spawnPosition.x = Random.Range(-14, 14);
        spawnPosition.y = -2.5f;
        spawnPosition.z = Random.Range(18, 14);

        //Instantiate(objects[UnityEngine.Random.Range(0, goodie.Length - 1)], spawnPosition, Quaternion.identity);
        Instantiate(ant_prefab, spawnPosition, Quaternion.identity);
    }
}
