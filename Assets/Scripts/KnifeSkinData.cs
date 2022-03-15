using System;
using UnityEngine;

[Serializable]
public class KnifeSkinData
{
    [SerializeField] private int _skinIndex;
    [SerializeField] private string _skinResourcesPath;

    public int SkinIndex => _skinIndex;
    public string SkinResourcesPath => _skinResourcesPath;
}
