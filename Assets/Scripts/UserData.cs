using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    private int _highestPoints;
    private int _money;
    private List<KnifeSkinData> _unlockedSkins = new List<KnifeSkinData>();

    public int Money { get => _money; set => _money = value;}

    public int HiestPoints => _highestPoints;

    public void UpdateRecord(int record)
    {
        if (record > _highestPoints)
        {
            _highestPoints = record;
        }
    }

    public void UnlockSkin(KnifeSkinData skinData)
    {
        _unlockedSkins.Add(skinData);
    }
}
