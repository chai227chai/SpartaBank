using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject sideButtons;

    private int setMoney;

    [Header("Deposit")]
    public GameObject depositCanvas;
    public TMP_InputField depositInputField;

    [Header("Withdraw")]
    public GameObject withdrawCanvas;
    public TMP_InputField withdrawInputField;

    [Header("Send")]
    public GameObject sendCanvas;
    public TMP_InputField sendTargetInputField;
    public TMP_InputField sendMoneyInputField;

    [Header("PopUP")]
    public GameObject noMoneyPopUp;
    public GameObject noTXTPopUp;
    public GameObject noOnePopUp;

    public event Action<int> OnDepositConfirm;
    public event Action<int> OnWithdrawConfirm;
    public event Action<int, string> OnSend;

    private void Awake()
    {
        instance = this;
    }

    private void RestInputText()
    {
        depositInputField.text = null;
        withdrawInputField.text = null;
        sendTargetInputField.text = null;
        sendMoneyInputField.text = null;
        setMoney = 0;
    }

    public void OnClickDepositButton()
    {
        RestInputText();
        depositCanvas.SetActive(true);
        sideButtons.SetActive(false);
    }

    public void OnClickWithdrawButton()
    {
        RestInputText();
        withdrawCanvas.SetActive(true);
        sideButtons.SetActive(false);
    }

    public void OnClickSendButton()
    {
        RestInputText();
        sendCanvas.SetActive(true);
        sideButtons.SetActive(false);
    }

    public void OnGoBackButton(GameObject obj)
    {
        obj.SetActive(false);
        sideButtons.SetActive(true);
    }

    public void OnClick_10000_Button(TMP_InputField inputField)
    {
        inputField.text = "10000";
    }

    public void OnClick_30000_Button(TMP_InputField inputField)
    {
        inputField.text = "30000";
    }

    public void OnClick_50000_Button(TMP_InputField inputField)
    {
        inputField.text = "50000";
    }

    public void OnClickDepositConfirm(TMP_InputField inputField)
    {
        if (inputField.text != string.Empty)
        {
            setMoney = int.Parse(inputField.text);
            OnDepositConfirm?.Invoke(setMoney);
        }
    }

    public void OnClickWithdrawConfirm(TMP_InputField inputField)
    {
        if (inputField.text != string.Empty)
        {
            setMoney = int.Parse(inputField.text);
            OnWithdrawConfirm?.Invoke(setMoney);
        }
    }

    public void OnSendButton()
    {
        string r = sendTargetInputField.text;

        if(sendTargetInputField.text != string.Empty && sendMoneyInputField.text != string.Empty)
        {
            if (PlayerPrefs.HasKey(r))
            {
                setMoney = int.Parse(sendMoneyInputField.text);
                OnSend?.Invoke(setMoney, r);
            }
            else
            {
                PopNoOne();
            }
        }
        else
        {
            PopNoTXT();
        }
    }

    private void PopNoOne()
    {
        noOnePopUp.SetActive(true);
    }

    private void PopNoTXT()
    {
        noTXTPopUp.SetActive(true);
    }

    public void PopNoMoney()
    {
        noMoneyPopUp.SetActive(true);
    }

    public void OnOkButton(GameObject obj)
    {
        obj.SetActive(false);
    }
}
