using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public float speed;
    public float detectionDistance = 1f;
    public float distance = 1f;
    private bool movingRight = true;
    public Transform groundDetection;
    public HeroController player;
    public MovementController playerController;


    private float cooldown = 3;
    private float lastDamage;

    private Vector2 startPos;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && (Time.time - lastDamage > cooldown))
        {
            playerController.Jumping();
            player.OnDamage();
            lastDamage = Time.time;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right *  speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, detectionDistance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }


        if (Mathf.Abs(transform.position.x - startPos.x) > distance)
        {
            if (Mathf.Abs(transform.position.x - startPos.x) > distance + 1)
            {
                gameObject.transform.position = startPos;
            }
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
