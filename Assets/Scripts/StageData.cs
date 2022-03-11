using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageData 
{
    [SerializeField] private int _stageNumber;
    [SerializeField] private KnifeStageData _knifeData;
    [SerializeField] private RotateStageData _rotateData;

    public KnifeStageData KnifeData => _knifeData;
    public RotateStageData RotateData => _rotateData;
    public int StageNumber => _stageNumber;
}
