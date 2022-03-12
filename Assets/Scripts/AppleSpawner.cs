using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private AppleChance _appleChance;
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private StageController _stageController;

    private void Awake()
    {
        _stageController.OnStageChanged += TryToSpawnApple;
    }

    private void Start()
    {
        TryToSpawnApple(1);
    }

    public void TryToSpawnApple(int stage)
    {
        Vector2 randomPointOnEdge;
        int change = Random.Range(0, _appleChance.Chance);
        if (change <= _appleChance.Chance)
        {
            randomPointOnEdge = Random.insideUnitCircle.normalized * (_circle.GetComponent<SphereCollider>().radius + 1);
            GameObject knife = Instantiate(_applePrefab, new Vector2(randomPointOnEdge.x + _circle.transform.position.x, randomPointOnEdge.y + _circle.transform.position.y), Quaternion.identity);
            knife.name = "Apple";
            knife.transform.SetParent(_circle.transform);
            Vector3 lookDirection = (knife.transform.localPosition - _circle.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            knife.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            knife.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
