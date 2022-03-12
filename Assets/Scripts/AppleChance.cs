using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Apple Chance", menuName = "Apple Chance", order = 42)]
public class AppleChance : ScriptableObject
{
    [Range (0, 100)]
    [SerializeField] private int _chance;

    public int Chance => _chance;
}
