using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserMoney : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
    private int _moneyAmount;

    private void Start()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (userData != null)
        {
            AddMoney(userData.Money);
        }
        else
        {
            AddMoney(0);
        }
    }

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        _moneyText.text = _moneyAmount.ToString();
    }

    public void IncrementMoney()
    {
        AddMoney(1);
    }
}
