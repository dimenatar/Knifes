using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KnifeThrower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private StageBundle _stageBundle;
    [SerializeField] private GameObject _knifePrefab;
    [SerializeField] private Transform _spawnPoint;

    private int _thrownKnifes;
    private int _availableKnifes;

    private GameObject _knife = null;

    private void Awake()
    {
        _stageBundle.OnStageChanged += SetAvailableKnifes;
    }

    private void Start()
    {
        SetAvailableKnifes(1);
    }

    private void SetAvailableKnifes(int stageNumber)
    {
        _thrownKnifes = 0;
        _availableKnifes = _stageBundle.GetCurrentStage().KnifeData.KnifeAmount;
        SpawnKnife();
    }    

    public void ThrowKnife()
    {
        if (_knife)
        {
            _knife.AddComponent<Rigidbody>();
            _knife.GetComponent<Rigidbody>().freezeRotation = true;
            _knife.AddComponent<KnifeMover>();
            _knife.GetComponent<KnifeMover>().SetSpeed(_speed);
            _knife = null;
            SpawnKnife();
        }
    }

    private void SpawnKnife()
    {
        if (_thrownKnifes < _availableKnifes)
        {
            _knife = Instantiate(_knifePrefab, _spawnPoint.position, Quaternion.Euler(Vector3.zero));
            _thrownKnifes++;
        }
    }
}
