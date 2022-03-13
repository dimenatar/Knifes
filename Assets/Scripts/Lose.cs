using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] private float _delayToShowLosePanel;
    [SerializeField] private GameObject _lostPane;

    public void ShowLosePanel()
    {
        Time.timeScale = 0.2f;
        _lostPane.SetActive(true);
    }
}
