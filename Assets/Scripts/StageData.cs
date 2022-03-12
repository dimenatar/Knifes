using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageData 
{
    [SerializeField] private int _stageNumber;
    [SerializeField] private KnifeStageData _knifeData;
    [SerializeField] private List<RotateStageData> _rotateData;
    [SerializeField] private Sprite _woodSprite;
    [SerializeField] private List<Sprite> _woodParts;

    public KnifeStageData KnifeData => _knifeData;
    public List<RotateStageData> RotateData => _rotateData;
    public int StageNumber => _stageNumber;
    public Sprite WoodSprite => _woodSprite;
    public List<Sprite> WoodParts => _woodParts;
}
