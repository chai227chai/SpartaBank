using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "NewUserData")]
public class UserData : ScriptableObject
{
    [Header("UserInfo")]
    public string id;
    public string userName;
    public int cash;
    public int leftMoney;

}
