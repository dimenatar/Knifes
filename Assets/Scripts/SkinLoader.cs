using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private KnifeSkinBundle _skinBundle;
    [SerializeField] private GameObject _backGroundPrefab;
    [SerializeField] private GameObject _scrollContent;
    [SerializeField] private Image _usersKnife;

    private void Start()
    {
        LoadSkins();
    }

    private void LoadSkins()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (userData == null)
        {
            userData = new UserData();
            userData.UnlockSkin(_skinBundle.Skins[0]);
            userData.SetUsersKnife(_skinBundle.Skins[0].SkinIndex);
            UserSaveManager.SaveUserData(UserSaveManager.Path, userData);
        }
        foreach (var item in userData.UnlockedSkins)
        {
            Debug.LogWarning(item.SkinResourcesPath);
        }
        _usersKnife.sprite = Resources.Load<Sprite>(userData.CurrentKnife.SkinResourcesPath);
        for (int i = 0; i < _skinBundle.Skins.Count; i++)
        {
            GameObject background = Instantiate(_backGroundPrefab, _scrollContent.transform);
            var skin = userData.UnlockedSkins.Where(skin => skin.SkinIndex == _skinBundle.Skins[i].SkinIndex).ToList();
            if (skin.Count == 0)
            {
                //if (!userData.UnlockedSkins.Contains(_skinBundle.Skins[i]))
                //{
                    background.GetComponent<Image>().color = Color.gray;
                //}
            }
            background.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(_skinBundle.Skins[i].SkinResourcesPath);
        }
    }
}
