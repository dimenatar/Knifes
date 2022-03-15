using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage Bundle", menuName = "Stage Bundle", order = 41)]
public class StageBundle : ScriptableObject
{
    [SerializeField] private List<StageData> _stages;

    public List<StageData> StageData => _stages;
}
