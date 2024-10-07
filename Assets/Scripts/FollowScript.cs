using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float noticeDistance = 4.0F;
    private bool shouldFollow = false;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);


        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (shouldFollow)
        {
            if (distance > 2)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
        else if (distance <= noticeDistance) { shouldFollow = true; }



    }
    private void OnTriggerEnter(Collider other)
    {

        shouldFollow = true;
        Debug.Log("Hello World!");


    }



}