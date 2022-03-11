using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage Bundle", menuName = "Stage Bundle", order = 41)]
public class StageBundle : ScriptableObject
{
    [SerializeField] private List<StageData> _stages;

    public delegate void StageChanged(int stage);
    public event StageChanged OnStageChanged;

    public List<StageData> StageData => _stages;

    private int _currentStage = 1;

    public int CurrentStage => _currentStage;

    public void IncrementStage()
    {
        if (_currentStage < _stages.Count)
        {
            _currentStage++;
            OnStageChanged?.Invoke(_currentStage);
        }
        else
        {
            _currentStage = 0;
        }
    }

    public StageData GetCurrentStage()
    {
        return _stages[_currentStage-1];
    }
}
