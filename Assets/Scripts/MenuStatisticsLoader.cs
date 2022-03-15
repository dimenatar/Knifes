using UnityEngine;
using UnityEngine.UI;

public class MenuStatisticsLoader : MonoBehaviour
{
    [SerializeField] private Text _stageText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _moneyText;

    private void Start()
    {
        LoadStatistics();
    }

    private void LoadStatistics()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (userData != null)
        {
            _stageText.text = userData.HighestStage.ToString();
            _scoreText.text = userData.HighestPoints.ToString();
            _moneyText.text = userData.Money.ToString();
        }
    }
}
