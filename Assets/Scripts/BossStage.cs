using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BossStage : UnityEngine.Object
{
    [SerializeField] private string _bossName;
    [SerializeField] private int _knifeIndex;

    public string BossName => _bossName;
    public int KnifeIndex => _knifeIndex;
}
