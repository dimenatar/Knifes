using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageController : MonoBehaviour
{
    [SerializeField] private StageBundle _stageBundle;
    [SerializeField] private EndGamePanel _endGamePanel;
    [SerializeField] private Text _stageText;

    private int _currentStage = 1;

    public delegate void StageChanged(StageData stage);
    public event StageChanged OnStageChanged;
    public event Action OnGameCompleted;

    private void Awake()
    {
        OnGameCompleted += _endGamePanel.ShowWinPanel;
        OnStageChanged += SetStageText;
    }

    private void Start()
    {
        OnStageChanged?.Invoke(_stageBundle.StageData[_currentStage - 1]);
    }

    public StageData GetCurrentStage()
    {
        return _stageBundle.StageData[_currentStage - 1];
    }

    public void IncrementStage()
    {
        if (_currentStage < _stageBundle.StageData.Count)
        {
            _currentStage++;
            OnStageChanged?.Invoke(_stageBundle.StageData[_currentStage - 1]);
        }
        else
        {
            OnGameCompleted?.Invoke();
        }
    }

    private void SetStageText(StageData stageData)
    {
        _stageText.transform.DOPunchScale(_stageText.transform.localScale * 1.5f, 0.5f, 2);
        _stageText.text = stageData.StageNumber.ToString();
    }
}
