using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class User : MonoBehaviour
{
    [Header("UserInfo")]
    public UserData userData;

    [Header("UserUI")]
    public TextMeshProUGUI userName;
    public TextMeshProUGUI userCash;
    public TextMeshProUGUI userLeftMoney;

    private void Awake()
    {
        
    }

    private void Start()
    {
        UIManager.instance.OnDepositConfirm += DepositMoney;
        UIManager.instance.OnWithdrawConfirm += WithdrawMoney;
        UIManager.instance.OnSend += SendMoney;

        SetUserName();
        UpdateCashUI();
        UpdateLeftUI();
    }

    public void SetUserName()
    {
        userName.text = userData.userName;
    }

    public void UpdateCashUI()
    {
        userCash.text = userData.cash.ToString("N0");
    }

    public void UpdateLeftUI()
    {
        userLeftMoney.text = userData.leftMoney.ToString("N0");
    }

    public void UpdateNowPlayerPrefs()
    {
        PlayerPrefs.SetInt(userData.id + "_Cash", userData.cash);
        PlayerPrefs.SetInt(userData.id + "_LeftMoney", userData.leftMoney);
        PlayerPrefs.Save();
    }

    public void SendMoneyPlayerPrefs(string sender, string receiver, int money)
    {
        PlayerPrefs.SetInt(sender + "_LeftMoney", PlayerPrefs.GetInt(sender + "_LeftMoney") - money);
        PlayerPrefs.SetInt(receiver + "_LeftMoney", PlayerPrefs.GetInt(receiver + "_LeftMoney") + money);
        PlayerPrefs.Save();
    }

    public void DepositMoney(int money)
    {
        if(userData.cash - money >= 0)
        {
            userData.cash -= money;
            userData.leftMoney += money;
            UpdateCashUI();
            UpdateLeftUI();
            UpdateNowPlayerPrefs();
        }
        else
        {
            UIManager.instance.PopNoMoney();
        }
    }

    public void WithdrawMoney(int money)
    {
        if (userData.leftMoney - money >= 0)
        {
            userData.leftMoney -= money;
            userData.cash += money;
            UpdateCashUI();
            UpdateLeftUI();
            UpdateNowPlayerPrefs();
        }
        else
        {
            UIManager.instance.PopNoMoney();
        }
    }

    public void SendMoney(int money, string target)
    {
        if (userData.leftMoney - money >= 0)
        {
            userData.leftMoney -= money;
            SendMoneyPlayerPrefs(userData.id, target, money);
            UpdateCashUI();
            UpdateLeftUI();
            UpdateNowPlayerPrefs();
        }
        else
        {
            UIManager.instance.PopNoMoney();
        }
    }
}
