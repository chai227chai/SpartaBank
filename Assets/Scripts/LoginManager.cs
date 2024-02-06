using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public UserData userData;

    [Header("Login")]
    public GameObject idPopUP;
    public GameObject passwordPopUp;
    public TMP_InputField idInput;
    public TMP_InputField passwordInput;

    [Header("SignUp")]
    public GameObject signUpPop;
    public GameObject errorPopUP;
    public TMP_InputField idSignUpInput;
    public TMP_InputField nameSignUpInput;
    public TMP_InputField passwordSignUpInput;
    public TMP_InputField passwordConfirmSignUpInput;
    public TextMeshProUGUI warningText;

    public void OnClickLogin()
    {
        string id = idInput.text;
        string pw = passwordInput.text;

        if (PlayerPrefs.HasKey(id))
        {
            if (pw.Equals(PlayerPrefs.GetString(id)))
            {
                userData.id = id;
                userData.userName = PlayerPrefs.GetString(id + "_Name");
                userData.cash = PlayerPrefs.GetInt(id + "_Cash");
                userData.leftMoney = PlayerPrefs.GetInt(id + "_LeftMoney");

                SceneManager.LoadScene("MainScene");
            }
            else
            {
                passwordPopUp.SetActive(true);
            }
        }
        else
        {
            idPopUP.SetActive(true);
        }
    }

    public void OnclickSignUpPopUP()
    {
        signUpPop.SetActive(true);
        idSignUpInput.text = string.Empty;
        nameSignUpInput.text = string.Empty;
        passwordSignUpInput.text = string.Empty;
        passwordConfirmSignUpInput.text = string.Empty;
    }

    public void OnClickSignUpButton()
    {
        string id = idSignUpInput.text;
        string name = nameSignUpInput.text;
        string password = passwordSignUpInput.text;
        string passwordConfirm = passwordConfirmSignUpInput.text;

        if (id.Equals(string.Empty))
        {
            SetWarning("���̵� �ݵ�� �ԷµǾ� �մϴ�.");
            return;
        }
        else if (id.Length < 3)
        {
            SetWarning("���̵�� 3~10���� ���̿��� �մϴ�.");
            return;
        }
        else if (CheckContainK(id))
        {
            SetWarning("���̵�� ����� ���ڷ� �̷������ �մϴ�.");
            return;
        }
        else if (PlayerPrefs.HasKey(id))
        {
            SetWarning("�̹� �����ϴ� ���̵� �Դϴ�.");
            return;
        }

        if (name.Equals(string.Empty))
        {
            SetWarning("�̸��� �ݵ�� �ԷµǾ� �մϴ�.");
            return;
        }
        else if(name.Length < 2)
        {
            SetWarning("�̸��� 2~5���� ���̿��� �մϴ�.");
            return;
        }

        if (password.Equals(string.Empty))
        {
            SetWarning("�н����尡 �ݵ�� �ԷµǾ� �մϴ�.");
            return;
        }
        else if(password.Length < 5)
        {
            SetWarning("�н������ 5~15���� ���̿��� �մϴ�.");
            return;
        }
        else if (CheckContainK(password))
        {
            SetWarning("�н������ ����� ���ڷ� �̷������ �մϴ�.");
            return;
        }

        if (passwordConfirm.Equals(string.Empty))
        {
            SetWarning("�н����� Ȯ���� �Է��ϼž� �մϴ�.");
            return;
        }
        else if (!passwordConfirm.Equals(password))
        {
            SetWarning("�н����� Ȯ���� ��ġ���� �ʽ��ϴ�.");
            return;
        }

        SetPlayerPrebs(id, name, password);

    }

    private void SetPlayerPrebs(string id, string name, string password)
    {
        PlayerPrefs.SetString(id, password);
        PlayerPrefs.SetString(id + "_Name", name);
        PlayerPrefs.SetInt(id + "_Cash", 100000);
        PlayerPrefs.SetInt(id + "_LeftMoney", 50000);
        PlayerPrefs.Save();

        signUpPop.SetActive(false);
    }

    private void SetWarning(string str)
    {
        warningText.text = str;
        warningText.gameObject.SetActive(true);
        errorPopUP.SetActive(true);
    }


    public bool CheckContainK(string str)
    {
        bool check = false;
        string specialChar = "!@#$%^&*()_+-=[]{};:,.<>/?`";

        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] >= 0xAc00 && str[i] <= 0xD7A3 || str[i] >= 0x3131 && str[i] <= 0x318E)
            {
                check = true;
                break;
            }
            else if (specialChar.Contains(str[i]))
            {
                check = true;
                break;
            }
        }

        return check;
    }

    public void OnClickClosePopUpButton(GameObject popUp)
    {
        popUp.SetActive(false);
    }
}
