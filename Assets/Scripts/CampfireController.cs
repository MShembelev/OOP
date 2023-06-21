using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireController : MonoBehaviour
{
    public GameObject player;


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            player.gameObject.GetComponent<HeroController>().OnHeal();
        }
    }
}
