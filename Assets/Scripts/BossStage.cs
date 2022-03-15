using System;
using UnityEngine;

[Serializable]
public class BossStage : object
{
    [SerializeField] private string _bossName;
    [SerializeField] private int _knifeIndex;

    public string BossName => _bossName;
    public int KnifeIndex => _knifeIndex;
}
