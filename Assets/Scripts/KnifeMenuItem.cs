using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Button))]
public class KnifeMenuItem : MonoBehaviour
{
    public delegate void SetSkin(string resourcePath);
    public event SetSkin OnSkinSet;

    private Button _knifeImageButton;
    private KnifeSkinData _skinData;
    private bool _isUnlocked;

    public Button KnifeImageButton => _knifeImageButton;

    private void Awake()
    {
        _knifeImageButton = GetComponent<Button>();
        _knifeImageButton.onClick.AddListener(SetCurrentKnife);
    }

    public void SetSkinData(KnifeSkinData skinData, bool isUnlocked)
    {
        _skinData = skinData;
        _isUnlocked = isUnlocked;
        if (!_isUnlocked)
        {
            _knifeImageButton.interactable = false;
        }
    }

    private void SetCurrentKnife()
    {
        if (_isUnlocked)
        {
            UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
            userData.SetUsersKnife(_skinData.SkinIndex);
            UserSaveManager.SaveUserData(UserSaveManager.Path, userData);
            OnSkinSet.Invoke(_skinData.SkinResourcesPath);
        }
    }
}
