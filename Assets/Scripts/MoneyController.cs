using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public int money = 0;
    public Text textField;

    private void UpdateMoney()
    {
        textField.text = $"{money}";
    }

    public void GiveMoney(int amount)
    {
        money += amount;
        UpdateMoney();
    }

    private void Start()
    {
        UpdateMoney();
    }
}
