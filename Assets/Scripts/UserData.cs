using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class UserData
{
    private int _highestPoints;
    private int _money;
    private int _highestStage;
    private List<KnifeSkinData> _unlockedSkins = new List<KnifeSkinData>();
    private KnifeSkinData _currentKnife;

    public int HighestStage => _highestStage;
    public int Money { get => _money; set => _money = value;}
    public int HighestPoints => _highestPoints;
    public KnifeSkinData CurrentKnife => _currentKnife;

    public List<KnifeSkinData> UnlockedSkins => _unlockedSkins;

    public void UpdateRecord(int record)
    {
        if (record > _highestPoints)
        {
            _highestPoints = record;
        }
    }

    public void UpdateHighestStage(int stage)
    {
        if (stage > _highestStage)
        {
            _highestStage = stage;
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
