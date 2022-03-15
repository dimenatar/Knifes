using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        _moneyText.transform.DOPunchScale(_moneyText.transform.localScale*1.5f, 0.5f, 2);
        _moneyText.text = _money.MoneyAmount.ToString();
        _scoreText.transform.DOPunchScale(_scoreText.transform.localScale * 1.5f, 0.5f, 2);
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
        if (!_lostPane.activeSelf)
        {
            SetTextValues();
            _lostPane.transform.localScale = Vector3.zero;
            _lostPane.SetActive(true);
            _lostPane.transform.DOScale(Vector3.one, 0.1f);
            Time.timeScale = 0.2f;
        }
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
