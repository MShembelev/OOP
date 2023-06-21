using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningController : MonoBehaviour
{
    public Text textField;
    private float startShow;
    private float cooldown = 5;
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Time.time - startShow > cooldown)
        {
            gameObject.SetActive(false);
        }
    }

    private void ChangeText(string text)
    {
        textField.text = text;
    }

    public void ShowAlert(string text, int timer)
    {
        ChangeText(text);
        cooldown = timer;
        gameObject.SetActive(true);
        startShow = Time.time;
    }
}
