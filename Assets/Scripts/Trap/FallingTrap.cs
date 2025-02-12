﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FallingTrap : TrapBase
{
    Rigidbody2D rb;
    bool fall = false;
    public float gravity;
    public float mass;
    private void Awake()
    {
        character = FindObjectOfType<CharacterController>();
        audioManager = FindObjectOfType<AudioManager>();
        heartManager = FindObjectOfType<HeartManager>();
        gameOverScreen = FindObjectOfType<GameOverScript>();
        trapType = TrapType.Effect;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fall)
        {
            if (collision.gameObject.tag == "Player")
            {              
                rb.isKinematic = false;
                rb.gravityScale = gravity;
                rb.mass = mass;
                fall = true;
                // Chỉ chạy rơi xuống chứ không tác động

            }
        }
    }
    //public override void attacked()
    //{
    //    base.attacked();
    //}

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Trap")
        {
            gameObject.tag = "Trap";
        }
        if (collision.gameObject != null && collision.gameObject.tag == "Player")
        {
            attacked();
        }
    }
}
