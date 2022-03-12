using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotator : MonoBehaviour
{
    [SerializeField] private StageController _stageController;

    private int _rotateStageIndex;
    private float _currentRotation;
    private float _passedTime;
    private bool _isGetRotateSpeed;
    private bool _isNeedToSlowDownRotation;
    private List<RotateStageData> _rotateData;

    private void Awake()
    {
        _stageController.OnStageChanged += SetStageData;
    }

    private void Start()
    {
        SetStageData(1);
    }

    private void Update()
    {
        Rotate();
    }

    private void SetStageData(int stage)
    {
        StageData data = _stageController.GetCurrentStage();
        if (data != null)
        {
            _rotateData = _stageController.GetCurrentStage().RotateData;
        }
    }

    private void Rotate()
    {
        if (!_isGetRotateSpeed && !_isNeedToSlowDownRotation)
        {
            SpinUp();
        }
        else if (_isGetRotateSpeed && !_isNeedToSlowDownRotation)
        {
            KeepSpeening();
        }
        else
        {
            SlowDown();
        }
    }

    private void SpinUp()
    {
        _passedTime += Time.deltaTime;
        _currentRotation = _rotateData[_rotateStageIndex].RotateSpeed / _rotateData[_rotateStageIndex].SpinUpTime * _passedTime;
        if (_currentRotation >= _rotateData[_rotateStageIndex].RotateSpeed)
        {
            _currentRotation = _rotateData[_rotateStageIndex].RotateSpeed;
            _passedTime = 0;
            _isGetRotateSpeed = true;
        }
        else
        {
            transform.Rotate(0, 0, _currentRotation);
        }
    }

    private void KeepSpeening()
    {
        _passedTime += Time.deltaTime;
        if (_passedTime >= _rotateData[_rotateStageIndex].SpinTime && _rotateData[_rotateStageIndex].SpinTime != 0)
        {
            _passedTime = 0;
            _isNeedToSlowDownRotation = true;
        }
        else
        {
            transform.Rotate(0, 0, _currentRotation);
        }
    }

    private void SlowDown()
    {
        _passedTime += Time.deltaTime;
        _currentRotation = _rotateData[_rotateStageIndex].RotateSpeed - _rotateData[_rotateStageIndex].RotateSpeed / _rotateData[_rotateStageIndex].SpinDownTime * _passedTime;
        if (_currentRotation <= 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            StartNewRotateStage();
            return;
        }
        else
        {
            transform.Rotate(0, 0, _currentRotation);
        }
    }

    private void StartNewRotateStage()
    {
        if (_rotateStageIndex == _rotateData.Count - 1)
        {
            _rotateStageIndex = 0;
            _isGetRotateSpeed = false;
            _isNeedToSlowDownRotation = false;
            _passedTime = 0;
            _currentRotation = 0;
        }
    }
}
