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
            SetWarning("아이디가 반드시 입력되야 합니다.");
            return;
        }
        else if (id.Length < 3)
        {
            SetWarning("아이디는 3~10글자 사이여야 합니다.");
            return;
        }
        else if (CheckContainK(id))
        {
            SetWarning("아이디는 영어와 숫자로 이루어져야 합니다.");
            return;
        }
        else if (PlayerPrefs.HasKey(id))
        {
            SetWarning("이미 존재하는 아이디 입니다.");
            return;
        }

        if (name.Equals(string.Empty))
        {
            SetWarning("이름이 반드시 입력되야 합니다.");
            return;
        }
        else if(name.Length < 2)
        {
            SetWarning("이름은 2~5글자 사이여야 합니다.");
            return;
        }

        if (password.Equals(string.Empty))
        {
            SetWarning("패스워드가 반드시 입력되야 합니다.");
            return;
        }
        else if(password.Length < 5)
        {
            SetWarning("패스워드는 5~15글자 사이여야 합니다.");
            return;
        }
        else if (CheckContainK(password))
        {
            SetWarning("패스워드는 영어와 숫자로 이루어져야 합니다.");
            return;
        }

        if (passwordConfirm.Equals(string.Empty))
        {
            SetWarning("패스워드 확인을 입력하셔야 합니다.");
            return;
        }
        else if (!passwordConfirm.Equals(password))
        {
            SetWarning("패스워드 확인이 일치하지 않습니다.");
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
