using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class KnifeStageData
{
    [SerializeField] private int _knifeAmount; // ������� ����� �������� ������������ �� �����

    public int KnifeAmount => _knifeAmount;
}
