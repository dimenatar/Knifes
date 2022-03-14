using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    [SerializeField] private float _delayToShowLosePanel;
    [SerializeField] private GameObject _lostPane;
    [SerializeField] private UserStatistics _userStatistics;
    [SerializeField] private UserMoney _money;
    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _scoreText;


    private void SetTextValues()
    {
        _moneyText.text = _money.MoneyAmount.ToString();
        _scoreText.text = _userStatistics.Stage.ToString();
    }

    public void ShowLosePanel()
    {
        SetTextValues();
        Time.timeScale = 0.2f;
        _lostPane.SetActive(true);
    }
}
