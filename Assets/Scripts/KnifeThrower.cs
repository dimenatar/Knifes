using DG.Tweening;
using UnityEngine;
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
    [SerializeField] private Text _wholeKnifeAmount;
    [SerializeField] private float _timeToReload;
    [SerializeField] private Timer _timer;

    private bool _canThrowAfterReload;
    private bool _canThrow = true;
    private Sprite _userSprite;
    private int _thrownKnifes;
    private int _availableKnifes;

    private GameObject _knife = null;

    private void Awake()
    {
        _stageController.OnStageChanged += SetAvailableKnifes;
        _timer.OnTime += AllowThrow;
    }

    private void Start()
    {
        _timer.Initialise(_timeToReload);
    }

    private void DisableThrowing()
    {
        _canThrow = false;
    }

    private void SetUserSprite()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        _userSprite = Resources.Load<Sprite>(userData.CurrentKnife.SkinResourcesPath);
    }

    private void AllowThrow()
    {
        _canThrowAfterReload = true;
    }

    public void ThrowKnife()
    {
        if (_knife && _canThrow && _canThrowAfterReload)
        {
            _canThrowAfterReload = false;
            _knife.AddComponent<Rigidbody>();
            _knife.GetComponent<Rigidbody>().freezeRotation = true;
            _knife.AddComponent<KnifeMover>();
            _knife.GetComponent<KnifeMover>().SetSpeed(_speed);
            _knife.GetComponent<BoxCollider>().enabled = true;
            _knife.GetComponent<KnifeMover>().OnKnifeHitOtherKnife += DisableThrowing;
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
            _availableKnifesText.transform.DOPunchScale(_availableKnifesText.transform.localScale * 1.5f, 0.5f, 2);
            _availableKnifesText.text = (_availableKnifes).ToString();
            _wholeKnifeAmount.transform.DOPunchScale(_wholeKnifeAmount.transform.localScale * 1.5f, 0.5f, 2);
            _wholeKnifeAmount.text = (_availableKnifes-1).ToString();
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
            _availableKnifesText.transform.DOPunchScale(_availableKnifesText.transform.localScale * 1.5f, 0.1f, 2);
            _availableKnifesText.text = (_availableKnifes - _thrownKnifes).ToString();
        }
    }
}
