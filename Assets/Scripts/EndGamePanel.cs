using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private float _delayToShowLosePanel;
    [SerializeField] private GameObject _lostPane;
    [SerializeField] private UserStatistics _userStatistics;
    [SerializeField] private UserMoney _money;
    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _resultText;

    private void SetTextValues()
    {
        _moneyText.text = _money.MoneyAmount.ToString();
        _scoreText.text = _userStatistics.Stage.ToString();
    }

    public void ShowLosePanel()
    {
        ShowPanel();
        ShowResult(true);
    }

    public void ShowWinPanel()
    {
        ShowPanel();
        ShowResult(false);
    }

    private void ShowPanel()
    {
        SetTextValues();
        Time.timeScale = 0.2f;
        _lostPane.SetActive(true);
    }

    private void ShowResult(bool isLose)
    {

        if (isLose)
        {
            _resultText.text = "You lose :(";
        }
        else
        {
            _resultText.text = "You win!";
        }
    }
}
