using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSkinData
{
    [SerializeField] private int _skinIndex;
    [SerializeField] private Sprite _skinImage;

    public int SkinINdex => _skinIndex;
    public Sprite SkinImage => _skinImage;
}
