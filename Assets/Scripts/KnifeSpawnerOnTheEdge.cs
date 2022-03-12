using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawnerOnTheEdge : MonoBehaviour
{
    [SerializeField] private int _minPossibleAmountKnifes;
    [SerializeField] private int _maxPossibleAmountKnifes;
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _knifePrefab;
    [SerializeField] private StageController _stageController;

    private void Awake()
    {
        _stageController.OnStageChanged += SpawnRandomAmountKnifes;
    }

    private void Start()
    {
        SpawnRandomAmountKnifes(1);
    }

    public void SpawnRandomAmountKnifes(int stage)
    {
        Vector2 randomPointOnEdge;
        int amountKnifes = Random.Range(_minPossibleAmountKnifes, _maxPossibleAmountKnifes);
        Debug.Log(amountKnifes);
        for (int i = 0; i < amountKnifes; i++)
        {
            randomPointOnEdge = Random.insideUnitCircle.normalized * (_circle.GetComponent<SphereCollider>().radius + 1);
            GameObject knife = Instantiate(_knifePrefab, new Vector2(randomPointOnEdge.x + _circle.transform.position.x, randomPointOnEdge.y + _circle.transform.position.y), Quaternion.identity);
            Destroy(knife.GetComponent<Knife>());
            knife.name = "Knife";
            knife.transform.SetParent(_circle.transform);
            Vector3 lookDirection = (knife.transform.localPosition - _circle.transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            knife.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
            knife.GetComponent<BoxCollider>().enabled = true;

        }
    }
}
