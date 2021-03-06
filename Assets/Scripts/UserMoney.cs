using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UserMoney : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
    private int _moneyAmount;

    public int MoneyAmount => _moneyAmount;

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
        _moneyText.transform.DOPunchScale(_moneyText.transform.localScale * 1.5f, 0.5f, 2);
        _moneyText.text = _moneyAmount.ToString();
    }

    public void IncrementMoney()
    {
        AddMoney(1);
    }
}
