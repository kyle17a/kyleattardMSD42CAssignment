﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //a variable that can be edited from Unity 
    [SerializeField] float health = 50f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;

    float xMin, xMax;

 




    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer DmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        Hit(DmgDealer);

    }

    private void Hit(DamageDealer DmgDealer)
    {
        health -= DmgDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void SetUpMoveBounderies()
    {
        Camera myCamera = Camera.main;
        xMin = myCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = myCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

    }

    private void Move()
    {

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        this.transform.position = new Vector2(newXpos, transform.position.y);

        
    }
}
