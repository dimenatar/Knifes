using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class KnifeThrower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private StageController _stageController;
    [SerializeField] private GameObject _knifePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EndGamePanel _lose;
    [SerializeField] private Text _availableKnifesText;
    [SerializeField] private UserStatistics _userStatistics;

    private Sprite _userSprite;
    private int _thrownKnifes;
    private int _availableKnifes;

    private GameObject _knife = null;

    private void Awake()
    {
        _stageController.OnStageChanged += SetAvailableKnifes;
    }

    private void SetUserSprite()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        _userSprite = Resources.Load<Sprite>(userData.CurrentKnife.SkinResourcesPath);
    }

    public void ThrowKnife()
    {
        if (_knife && Time.timeScale >= 1)
        {
            _knife.AddComponent<Rigidbody>();
            _knife.GetComponent<Rigidbody>().freezeRotation = true;
            _knife.AddComponent<KnifeMover>();
            _knife.GetComponent<KnifeMover>().SetSpeed(_speed);
            _knife.GetComponent<BoxCollider>().enabled = true;
            _knife.GetComponent<KnifeMover>().OnKnifeHitOtherKnife += _lose.ShowLosePanel;
            _knife.GetComponent<KnifeMover>().OnKnifeHitOtherKnife += _userStatistics.CollectStatistics;
            _knife.GetComponent<KnifeMover>().OnKnifeHitOtherKnife += ClassicVibrate;
            _knife = null;
            SpawnKnife();
        }
    }

    private void ClassicVibrate()
    {
        Vibration.Init();
        Vibration.Vibrate();
    }

    private void SetAvailableKnifes(StageData stage)
    {
        SetUserSprite();
        _thrownKnifes = 0;
        StageData data = stage;
        if (data != null)
        {
            _availableKnifes = data.KnifeData.KnifeAmount;
            _availableKnifesText.text = (_availableKnifes).ToString();
            SpawnKnife();
        }
    }    


    private void SpawnKnife()
    {
        if (_thrownKnifes < _availableKnifes)
        {
            _knife = Instantiate(_knifePrefab, _spawnPoint.position, Quaternion.Euler(Vector3.zero));
            _knife.GetComponent<SpriteRenderer>().sprite = _userSprite;
            _knife.name = "Knife";
            _thrownKnifes++;
            _availableKnifesText.text = (_availableKnifes - _thrownKnifes).ToString();
        }
    }
}
