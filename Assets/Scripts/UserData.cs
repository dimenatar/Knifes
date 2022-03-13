using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UserData
{
    private int _highestPoints;
    private int _money;
    private List<KnifeSkinData> _unlockedSkins = new List<KnifeSkinData>();
    private KnifeSkinData _currentKnife;

    public int Money { get => _money; set => _money = value;}
    public int HiestPoints => _highestPoints;
    public KnifeSkinData CurrentKnife => _currentKnife;

    public List<KnifeSkinData> UnlockedSkins => _unlockedSkins;

    public void UpdateRecord(int record)
    {
        if (record > _highestPoints)
        {
            _highestPoints = record;
        }
    }

    public void SetUsersKnife(int index)
    {
        _currentKnife = _unlockedSkins.Where(skin => skin.SkinIndex == index).FirstOrDefault();
    }

    public void UnlockSkin(KnifeSkinData skinData)
    {
        if (!_unlockedSkins.Contains(skinData))
        {
            _unlockedSkins.Add(skinData);
        }
    }
}
