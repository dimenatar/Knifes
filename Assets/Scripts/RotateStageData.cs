using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RotateStageData 
{
    [SerializeField] private float _spinUpTime; // время, чтобы набрать скорость
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _spinDownTime; // время на остановку движения
    [SerializeField] private float _spinTime; // время кручения

    public float SpinUpTime => _spinUpTime;
    public float RotateSpeed => _rotateSpeed;
    public float SpinDownTime => _spinDownTime;
    public float SpinTime => _spinTime;
}
