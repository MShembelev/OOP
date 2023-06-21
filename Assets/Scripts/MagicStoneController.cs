using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicStoneController : MonoBehaviour
{
    public MovementController player;
    public int amountAbility = 3;
    public bool isActive = true;

    public bool isRevive = false;
    public int reviveCooldown = 15;

    public WarningController warningController;
    private float lastWork;

    private void FixedUpdate()
    {
        if (isRevive && (Time.time - lastWork > reviveCooldown))
        {
            isActive = true;
            changeTheme();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && isActive && Input.GetKeyDown(KeyCode.E))
        {
            if (col.gameObject.GetComponent<MovementController>().abilityLeft > 0)
            {
                warningController.ShowAlert("У вас уже есть способность", 10);
                return;
            }
            player.abilityLeft += amountAbility;
            isActive = false;
            lastWork = Time.time;
            changeTheme();
        }
    }

    public void changeTheme()
    {
        transform.GetChild(0).gameObject.SetActive(isActive);
    }
}
