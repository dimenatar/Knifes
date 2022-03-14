using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private StageBundle _stageBundle;

    private int _currentStage = 1;

    public delegate void StageChanged(StageData stage);
    public event StageChanged OnStageChanged;
    public event Action OnGameCompleted;

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
        }
        else
        {
            _currentStage = 1;
        }
        OnStageChanged?.Invoke(_stageBundle.StageData[_currentStage-1]);
    }
}
