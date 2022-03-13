using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KnifeSkinData
{
    [SerializeField] private int _skinIndex;
    [SerializeField] private Sprite _skinImage;

    public int SkinIndex => _skinIndex;
    public Sprite SkinImage => _skinImage;
}
