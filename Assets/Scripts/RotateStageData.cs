using System;
using UnityEngine;

[Serializable]
public class RotateStageData 
{
    [SerializeField] private float _spinUpTime; // �����, ����� ������� ��������
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _spinDownTime; // ����� �� ��������� ��������
    [SerializeField] private float _spinTime; // ����� ��������

    public float SpinUpTime => _spinUpTime;
    public float RotateSpeed => _rotateSpeed;
    public float SpinDownTime => _spinDownTime;
    public float SpinTime => _spinTime;
}
