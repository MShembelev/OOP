using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public int MaxAmount = 100;
    public WarningController WarningController;
    public MoneyController MoneyController;

    private GameObject chestClose;
    private GameObject chestOpen;

    private void Start()
    {
        chestOpen = gameObject.transform.GetChild(1).gameObject;
        chestClose = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            int amount = Random.Range(1, MaxAmount);
            WarningController.ShowAlert($"Вы нашли {amount} золотых", 7);
            MoneyController.GiveMoney(amount);
            isOpen = true;
            changeTheme();
        }
    }

    public void changeTheme()
    {
        if (isOpen)
        {
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
        }
        else
        {
            chestOpen.SetActive(false);
            chestClose.SetActive(true);
        }
    }
}
