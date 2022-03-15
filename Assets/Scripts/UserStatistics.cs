using UnityEngine;

public class UserStatistics : MonoBehaviour
{
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private StageController _stageController;

    private int _stage;
    private int _score;

    public int Stage => _stage;
    public int Score => _score;

    private void Awake()
    {
        _stageController.OnStageChanged += IncrementStage;
    }

    public void IncrementScore()
    {
        _score++;
    }

    public void IncrementStage(StageData stageData)
    {
        _stage++;
    }

    public void CollectStatistics()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        userData.Money = _userMoney.MoneyAmount;
        userData.UpdateRecord(_score);
        userData.UpdateHighestStage(_stage);
        UserSaveManager.SaveUserData(UserSaveManager.Path, userData);
    }
}
