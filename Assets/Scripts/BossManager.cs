using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class BossManager : MonoBehaviour
{
    [SerializeField] private KnifeSkinBundle _knifeSkinBundle;
    [SerializeField] private StageController _stageController;
    [SerializeField] private Wood _wood;
    [SerializeField] private Text _bossName;

    private void Awake()
    {
        _stageController.OnStageChanged += CheckIfBossStage;
        _wood.OnStageCompleted += SaveBossSkin;
    }



    private void CheckIfBossStage(StageData stageData)
    {
        if (!String.IsNullOrEmpty(stageData.BossStage.BossName))
        {
            _bossName.enabled = true;
            _bossName.text = "Boss stage: " + stageData.BossStage.BossName + "!";
            _bossName.transform.DOPunchScale(_bossName.transform.localScale * 1.5f, 0.5f, 2);
            Invoke(nameof(HideBossName), 1f);
        }
    }

    private void HideBossName()
    {
        _bossName.enabled = false;
    }

    private void SaveBossSkin(StageData stageData)
    {
        if (!String.IsNullOrEmpty(stageData.BossStage.BossName))
        {
            SaveUserSkin(stageData.BossStage.KnifeIndex);
        }
    }

    private void SaveUserSkin(int knifeIndex)
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        userData.UnlockSkin(_knifeSkinBundle.Skins.Where(skin => skin.SkinIndex == knifeIndex).FirstOrDefault());
        UserSaveManager.SaveUserData(UserSaveManager.Path, userData);
    }
}
