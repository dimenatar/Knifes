using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private AppleChance _appleChance;
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private StageController _stageController;
    [SerializeField] private UserMoney _money;

    private void Awake()
    {
        _stageController.OnStageChanged += TryToSpawnApple;
    }

    private void Start()
    {
        //TryToSpawnApple(1);
    }

    public void TryToSpawnApple(StageData stage)
    {
        Vector2 randomPointOnEdge;
        int change = Random.Range(0, 100);
        if (change <= _appleChance.Chance)
        {
            randomPointOnEdge = Random.insideUnitCircle.normalized * (_circle.GetComponent<SphereCollider>().radius + 1.5f);
            GameObject apple = Instantiate(_applePrefab, new Vector2(randomPointOnEdge.x + _circle.transform.position.x, randomPointOnEdge.y + _circle.transform.position.y), Quaternion.identity);
            apple.name = "Apple";
            apple.GetComponent<Apple>().OnAppleHitted += _money.IncrementMoney;
            apple.transform.SetParent(_circle.transform);
            Vector3 lookDirection = (apple.transform.localPosition - _circle.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            apple.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            apple.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
