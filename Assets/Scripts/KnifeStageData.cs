using System;
using UnityEngine;

[Serializable]
public class KnifeStageData
{
    [SerializeField] private int _knifeAmount; // ������� ����� �������� ������������ �� �����

    public int KnifeAmount => _knifeAmount;
}
