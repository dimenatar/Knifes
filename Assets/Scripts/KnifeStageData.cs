using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class KnifeStageData
{
    [SerializeField] private int _knifeAmount; // сколько кожей доступно пользователю на этапе

    public int KnifeAmount => _knifeAmount;
}
