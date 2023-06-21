using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeroController : MonoBehaviour
{
    public int health = 3;
    public GameObject healthBar;
    public MoneyController MoneyController;
    private Vector2 revivePos;

    public WarningController wC;
    private void Start()
    {
        revivePos = transform.position;
    }

    public void OnDamage()
    {
        health--;
        setHearts();
        if(health < 1){ onDeath();}

    }

    private void onDeath()
    {
        transform.position = revivePos;
        health = 3;
        setHearts();
        int LooseMoney = Random.Range(0, MoneyController.money);
        wC.ShowAlert($"Вы погибли и потеряли {LooseMoney} золотых", 3);
        MoneyController.GiveMoney(LooseMoney * (-1));
    }

    public void OnHeal()
    {
        health = 3;
        setHearts();
    }
    public void SetCheckpoint(Vector2 revive)
    {
        revivePos = revive;
    }

    private void setHearts()
    {
        healthBar.transform.GetChild(0).gameObject.SetActive(health > 0);
        healthBar.transform.GetChild(1).gameObject.SetActive(health > 1);
        healthBar.transform.GetChild(2).gameObject.SetActive(health > 2);
    }
}
